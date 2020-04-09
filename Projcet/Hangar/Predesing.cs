using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using System.Windows.Forms;

namespace Hangar
{
    /// <summary>
    /// Класс проектирования, хранящий в себе методы проверки совместимости введённых пар-ров и создания&&вхождения объектов в среду автокад.
    /// </summary>
    class Desing
    {
        /// <summary>
        /// Класс хранящий в себе введённые пользователем пар-ры ангара.
        /// </summary>
        public HangarParam hangarParam;
        /// <summary>
        /// Коэф надёжности строения.
        /// </summary>
        private double _safetyMargin = 1.2;
        /// <summary>
        /// Удельный вес профлиста крыши.
        /// </summary>
        private int _specificProfiledSheet = 50;
        /// <summary>
        /// Удельные вес стальных листов стен и ворот.
        /// </summary>
        private int _specificSteelSheet = 60;
        /// <summary>
        /// Удельный вес железобетонного фундамента и подстенки (подошвы).
        /// </summary>
        private int _specificReinforcedConcrete = 2500;
        /// <summary>
        /// Среднесезонные снеговые нагрузки.
        /// </summary>
        private int _specificSnow = 350;
        /// <summary>
        /// Длина сваи.
        /// </summary>
        private double _heightPiles;
        /// <summary>
        /// Число свай.
        /// </summary>
        private int _quantityPiles;

        /// <summary>
        /// Метод производит расчёт веса ангара, сравнивая его с нагрузкой грунта.
        /// Если грунт не способен выдержать, тогда происходит перерасчёт параметров с учётом второго грунта, далее с третьим. Если здание слишком тяжело, тогда
        /// генерируется исключение.
        /// Если грунт подходящий, происходит подсчёт длины свай и запуск процесса отрисовки ангара.
        /// </summary>
        public void CheckCompatibility()
        {
            _quantityPiles = (1 + (int)hangarParam.HangarLength / 2) * 2;
            double areaRoof = hangarParam.HangarLength * hangarParam.HangarWidth;
            double areaWall = (hangarParam.HangarHeight * hangarParam.HangarWidth + hangarParam.HangarHeight * hangarParam.HangarLength) * 2;
            double perimeterWall = (hangarParam.HangarLength + hangarParam.HangarWidth) * 2;
            double weight = areaRoof * _specificSnow + areaRoof * _specificProfiledSheet + areaWall * _specificSteelSheet + _specificReinforcedConcrete * perimeterWall * 0.2 * hangarParam.WallHeight;
            double firstLoad = hangarParam.FirstSoil.Load * 1.4 * hangarParam.FirstSoil.Size;
            double secondLoad = hangarParam.SecondSoil.Load * 1.4 * hangarParam.SecondSoil.Size;
            double thirdLoad = hangarParam.ThirdSoil.Load * 1.4 * hangarParam.ThirdSoil.Size;
            if (weight * _safetyMargin / (625 * firstLoad) > _quantityPiles)
                if (weight * _safetyMargin / (625 * (secondLoad + firstLoad)) > _quantityPiles)
                    if (weight * _safetyMargin / (625 * (secondLoad + firstLoad+ thirdLoad)) > _quantityPiles)
                        throw new System.Exception("Ни один из слоёв грунта не способен выдержать ангар с весом = " + weight + " кг.");
                    else
                        _heightPiles = hangarParam.FirstSoil.Size + hangarParam.SecondSoil.Size +(weight * _safetyMargin / (625 * _quantityPiles) - firstLoad- secondLoad)/ hangarParam.ThirdSoil.Load * 1.4;
                   else
                    _heightPiles = hangarParam.FirstSoil.Size + (weight * _safetyMargin / (625 * _quantityPiles) - firstLoad) / hangarParam.SecondSoil.Load * 1.4;
                else
                _heightPiles = weight*_safetyMargin/(625* _quantityPiles * hangarParam.FirstSoil.Load * 1.4);
            DrawHangar();
        }

        /// <summary>
        /// Метод производит подключение к автокаду и в порядке очерёдности создаёт объекты, помещая их в базу данных. После чего производит вхождение объектов в автокад.
        /// </summary>
        private void DrawHangar()
        {
            // получаем ссылки на документ и его БД
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            // поле документа "Editor" понадобится нам для вывода сообщений в окно консоли AutoCAD
            Editor ed = doc.Editor;
            // начинаем транзакцию
            Transaction tr = db.TransactionManager.StartTransaction();
            // имя создаваемого блока
            string blockName;
            for (int i = 0; i < _quantityPiles; i++)
            {
                blockName = "Pile" + i;
                if ((i % 2) > 0)
                    DrawObject((int)(i / 2) * hangarParam.HangarLength / (_quantityPiles/2 - 1) , 0, 0, 0.25, 0.25, _heightPiles);
                else
                    DrawObject((int)(i / 2) * hangarParam.HangarLength / (_quantityPiles/2 - 1) , hangarParam.HangarWidth, 0, 0.25, 0.25, _heightPiles);
            }
            for (int i = 0; i < 2; i++)
            {
                blockName = "LongWall" + i;
                if (i == 0)
                    DrawObject((0.25 - 0.2) / 2, (0.25 - 0.2) / 2, _heightPiles, hangarParam.HangarLength + 0.2, 0.2, hangarParam.WallHeight);
                else
                    DrawObject((0.25 - 0.2) / 2, (0.25 - 0.2) / 2 + hangarParam.HangarWidth, _heightPiles, hangarParam.HangarLength + 0.2, 0.2, hangarParam.WallHeight);
            }
            blockName = "Hangar";
            DrawObject(0.25 / 2, 0.25 / 2, _heightPiles + hangarParam.WallHeight, hangarParam.HangarLength, hangarParam.HangarWidth, hangarParam.HangarHeight);
            blockName = "FontWallLeft";
            DrawObject((0.25 - 0.2) / 2, 0.25-(0.25 - 0.2) / 2, _heightPiles, 0.2, (hangarParam.HangarWidth - hangarParam.GateWidth -0.25 + (0.25 - 0.2)) / 2, hangarParam.WallHeight);
            blockName = "FontWallRigth";
            DrawObject((0.25 - 0.2) / 2, 0.25 - (0.25 - 0.2) / 2 + (hangarParam.HangarWidth - hangarParam.GateWidth - 0.25 + (0.25 - 0.2)) / 2+ hangarParam.GateWidth, _heightPiles, 0.2, (hangarParam.HangarWidth - hangarParam.GateWidth) / 2, hangarParam.WallHeight);
            blockName = "Gate";
            DrawObject(0.25 / 2, (0.25 + hangarParam.HangarWidth - hangarParam.GateWidth) / 2, _heightPiles + hangarParam.WallHeight, 0, hangarParam.GateWidth, hangarParam.GateHeight);
            blockName = "BackWall";
            DrawObject((0.25-0.2) / 2+ hangarParam.HangarLength, (0.25 - 0.2) / 2 + 0.2, _heightPiles, 0.2, hangarParam.HangarWidth - 0.2, hangarParam.WallHeight);
            blockName = "Roof";
            DrawObject(0, (hangarParam.HangarWidth + 0.25) / 2, _heightPiles +hangarParam.WallHeight+hangarParam.HangarHeight,hangarParam.HangarLength+0.25,hangarParam.HangarWidth,0);

            //Внутренний метод DrawHangar-а, который создаёт объект по заданным координатам и размерам.
            void DrawObject(double x, double y, double z, double length, double width, double height)
            {
                // ШАГ 1 - создаем новую запись в таблице блоков
                doc.LockDocument();
                // открываем таблицу блоков на запись
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                // вначале проверяем, нет ли в таблице блока с таким именем
                // если есть - выводим сообщение об ошибке и заканчиваем выполнение команды
                if (bt.Has(blockName))
                {
                    ed.WriteMessage("\nA block with the name \"" + blockName + "\" already exists.");
                    return;
                }
                // создаем новое определение блока, задаем ему имя
                BlockTableRecord btr = new BlockTableRecord();
                btr.Name = blockName;
                // добавляем созданное определение блока в таблицу блоков и в транзакцию,
                // запоминаем ID созданного определения блока (оно пригодится чуть позже)
                ObjectId btrId = bt.Add(btr);
                tr.AddNewlyCreatedDBObject(btr, true);
                // ШАГ 2 - добавляем к созданной записи необходимые геометрические примитивы
                Polyline3d acPoly3d = new Polyline3d();
                acPoly3d.ColorIndex = 5;
                // Add the new object to the block table record and the transaction
                btr.AppendEntity(acPoly3d);
                tr.AddNewlyCreatedDBObject(acPoly3d, true);
                // Before adding vertexes, the polyline must be in the drawing
                Point3dCollection acPts3dPoly = new Point3dCollection();
                if(height>0)
                    acPts3dPoly = CreateCube();
                else
                    acPts3dPoly = CreateRoof();
                foreach (Point3d acPt3d in acPts3dPoly)
                {
                    using (PolylineVertex3d acPolVer3d = new PolylineVertex3d(acPt3d))
                    {
                        acPoly3d.AppendVertex(acPolVer3d);
                        tr.AddNewlyCreatedDBObject(acPolVer3d, true);
                    }
                }
                // ШАГ 3 - добавляем вхождение созданного блока на чертеж
                // открываем пространство модели на запись
                BlockTableRecord ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                // создаем новое вхождение блока, используя ранее сохраненный ID определения блока
                BlockReference br = new BlockReference(Point3d.Origin, btrId);
                // добавляем созданное вхождение блока на пространство модели и в транзакцию
                ms.AppendEntity(br);
                tr.AddNewlyCreatedDBObject(br, true);

                // Внутренний метод DrawObject-а, который с помощью полилинии заполняет коллекцию точек в виде куба по соответствующим координатам и размерам. 
                // По умолчанию все данные в метрах. Полилиния рисует обекты помноженные на 1000, то есть в милиметрах.
                Point3dCollection CreateCube()
                {
                    x = x * 1000;
                    y = y * 1000;
                    z = z * 1000;
                    length = length * 1000;
                    width = width * 1000;
                    height = height * 1000;
                    Point3dCollection cube = new Point3dCollection();
                    cube.Add(new Point3d(x, y, z));
                    cube.Add(new Point3d(x + length, y, z));
                    cube.Add(new Point3d(x + length, y + width, z));
                    cube.Add(new Point3d(x, y + width, z));
                    cube.Add(new Point3d(x, y, z));
                    cube.Add(new Point3d(x, y, z + height));
                    cube.Add(new Point3d(x + length, y, z + height));
                    cube.Add(new Point3d(x + length, y + width, z + height));
                    cube.Add(new Point3d(x, y + width, z + height));
                    cube.Add(new Point3d(x, y, z + height));
                    cube.Add(new Point3d(x + length, y, z + height));
                    cube.Add(new Point3d(x + length, y, z));
                    cube.Add(new Point3d(x + length, y + width, z));
                    cube.Add(new Point3d(x + length, y + width, z + height));
                    cube.Add(new Point3d(x, y + width, z + height));
                    cube.Add(new Point3d(x, y + width, z));
                    return cube;
                }

                // Отдельный метод для отрисовывания крыши ангара, так как этот объект не состоит из параллелепипедов.
                Point3dCollection CreateRoof()
                {
                    x = x * 1000;
                    y = y * 1000;
                    z = z * 1000;
                    length = length * 1000;
                    width = width * 1000;
                    Point3dCollection roof = new Point3dCollection();
                    roof.Add(new Point3d(x, y, z+ Math.Sqrt(width * width / 12)));
                    roof.Add(new Point3d(x, y + width / 2+ 86, z-50));
                    roof.Add(new Point3d(x + length, y + width / 2 + 86, z - 50));
                    roof.Add(new Point3d(x + length, y, z + Math.Sqrt(width * width / 12)));
                    roof.Add(new Point3d(x + length, y - width / 2- 86, z - 50));
                    roof.Add(new Point3d(x, y - width / 2 -86, z - 50));
                    roof.Add(new Point3d(x, y, z + Math.Sqrt(width * width / 12)));
                    return roof;
                }
            }
            // фиксируем транзакцию
            tr.Commit();
        }
    }
}
