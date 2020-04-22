using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using HangarModel;
using HangarGUI;
using System.Windows.Forms;
using Autodesk.AutoCAD.Runtime;
using System;

namespace HangarAPI
{
    public class Program
    {
        /// <summary>
        /// Commands реализует интерфейс автокада, храня в себе обязательные методы.
        /// </summary>
        public class Commands : IExtensionApplication
        {

            // функция Initialize() необходима, чтобы реализовать интерфейс IExtensionApplication. Запускается при загрузке библиотеки.
            public void Initialize()
            {
                MessageBox.Show("Welcome!");
                HangarParam hangarParam = new HangarParam();
                Form mainForm = new MainForm(hangarParam);
                mainForm.Show();
                if (mainForm.DialogResult == DialogResult.OK)
                    DrawHangar(hangarParam);
            }



            // функция Terminate() необходима, чтобы реализовать интерфейс IExtensionApplication. Запускается при закрытии автокада.
            public void Terminate()
            {

            }

            /// <summary>
            /// Метод производит подключение к автокаду и в порядке очерёдности создаёт объекты, помещая их в базу данных. После чего производит вхождение объектов в автокад.
            private void DrawHangar(HangarParam hangarParam)
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
                for (int i = 0; i < hangarParam.QuantityPiles; i++)
                {
                    blockName = "Pile" + i;
                    if ((i % 2) > 0)
                        DrawObject((int)(i / 2) * hangarParam.HangarLength / (hangarParam.QuantityPiles / 2 - 1), 0, 0, 0.25, 0.25, hangarParam.HeightPiles);
                    else
                        DrawObject((int)(i / 2) * hangarParam.HangarLength / (hangarParam.QuantityPiles / 2 - 1), hangarParam.HangarWidth, 0, 0.25, 0.25, hangarParam.HeightPiles);
                }
                for (int i = 0; i < 2; i++)
                {
                    blockName = "LongWall" + i;
                    if (i == 0)
                        DrawObject((0.25 - 0.2) / 2, (0.25 - 0.2) / 2, hangarParam.HeightPiles, hangarParam.HangarLength + 0.2, 0.2, hangarParam.WallHeight);
                    else
                        DrawObject((0.25 - 0.2) / 2, (0.25 - 0.2) / 2 + hangarParam.HangarWidth, hangarParam.HeightPiles, hangarParam.HangarLength + 0.2, 0.2, hangarParam.WallHeight);
                }
                blockName = "Hangar";
                DrawObject(0.25 / 2, 0.25 / 2, hangarParam.HeightPiles + hangarParam.WallHeight, hangarParam.HangarLength, hangarParam.HangarWidth, hangarParam.HangarHeight);
                blockName = "FontWallLeft";
                DrawObject((0.25 - 0.2) / 2, 0.25 - (0.25 - 0.2) / 2, hangarParam.HeightPiles, 0.2, (hangarParam.HangarWidth - hangarParam.GateWidth - 0.25 + (0.25 - 0.2)) / 2, hangarParam.WallHeight);
                blockName = "FontWallRigth";
                DrawObject((0.25 - 0.2) / 2, 0.25 - (0.25 - 0.2) / 2 + (hangarParam.HangarWidth - hangarParam.GateWidth - 0.25 + (0.25 - 0.2)) / 2 + hangarParam.GateWidth, hangarParam.HeightPiles, 0.2, (hangarParam.HangarWidth - hangarParam.GateWidth) / 2, hangarParam.WallHeight);
                blockName = "Gate";
                DrawObject(0.25 / 2, (0.25 + hangarParam.HangarWidth - hangarParam.GateWidth) / 2, hangarParam.HeightPiles + hangarParam.WallHeight, 0, hangarParam.GateWidth, hangarParam.GateHeight);
                blockName = "BackWall";
                DrawObject((0.25 - 0.2) / 2 + hangarParam.HangarLength, (0.25 - 0.2) / 2 + 0.2, hangarParam.HeightPiles, 0.2, hangarParam.HangarWidth - 0.2, hangarParam.WallHeight);
                blockName = "Roof";
                DrawObject(0, (hangarParam.HangarWidth + 0.25) / 2, hangarParam.HeightPiles + hangarParam.WallHeight + hangarParam.HangarHeight, hangarParam.HangarLength + 0.25, hangarParam.HangarWidth, 0);

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
                    if (height > 0)
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
                        roof.Add(new Point3d(x, y, z + Math.Sqrt(width * width / 12)));
                        roof.Add(new Point3d(x, y + width / 2 + 86, z - 50));
                        roof.Add(new Point3d(x + length, y + width / 2 + 86, z - 50));
                        roof.Add(new Point3d(x + length, y, z + Math.Sqrt(width * width / 12)));
                        roof.Add(new Point3d(x + length, y - width / 2 - 86, z - 50));
                        roof.Add(new Point3d(x, y - width / 2 - 86, z - 50));
                        roof.Add(new Point3d(x, y, z + Math.Sqrt(width * width / 12)));
                        return roof;
                    }
                }
                // фиксируем транзакцию
                tr.Commit();
            }
        }
    }
}
