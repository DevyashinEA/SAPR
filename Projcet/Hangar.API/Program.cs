using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using HangarModel;
using HangarGUI;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Windows.Forms;

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
                mainForm.ShowDialog();
                DrawHangar(hangarParam);
            }

            // функция Terminate() необходима, чтобы реализовать интерфейс IExtensionApplication. Запускается при закрытии автокада.
            public void Terminate()
            {

            }

            /// <summary>
            /// Метод производит подключение к автокаду и в порядке очерёдности создаёт объекты, помещая их в базу данных. После чего производит вхождение объектов в автокад.
            /// <summary>
            private void DrawHangar(HangarParam hangarParam)
            {
                Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                Database db = doc.Database;
                Editor ed = doc.Editor;
                Transaction tr = db.TransactionManager.StartTransaction();
                double sidePile = 0.25;
                double bulgingPilesAgainstWall = 0.2;
                string blockName;
                for (int i = 0; i < hangarParam.QuantityPiles; i++)
                {
                    blockName = "Pile" + i;
                    if ((i % 2) > 0)
                        DrawObject((int)(i / 2) * hangarParam.HangarLength / (hangarParam.QuantityPiles / 2 - 1), 0, 0, areaPile, areaPile, hangarParam.HeightPiles);
                    else
                        DrawObject((int)(i / 2) * hangarParam.HangarLength / (hangarParam.QuantityPiles / 2 - 1), hangarParam.HangarWidth, 0, areaPile, areaPile, hangarParam.HeightPiles);
                }
                for (int i = 0; i < 2; i++)
                {
                    blockName = "LongWall" + i;
                    if (i == 0)
                        DrawObject((areaPile - bulgingPilesAgainstWall) / 2, (areaPile - bulgingPilesAgainstWall) / 2, hangarParam.HeightPiles, hangarParam.HangarLength + bulgingPilesAgainstWall, bulgingPilesAgainstWall, hangarParam.WallHeight);
                    else
                        DrawObject((areaPile - bulgingPilesAgainstWall) / 2, (areaPile - bulgingPilesAgainstWall) / 2 + hangarParam.HangarWidth, hangarParam.HeightPiles, hangarParam.HangarLength + bulgingPilesAgainstWall, bulgingPilesAgainstWall, hangarParam.WallHeight);
                }
                blockName = "Hangar";
                DrawObject(areaPile / 2, areaPile / 2, hangarParam.HeightPiles + hangarParam.WallHeight, hangarParam.HangarLength, hangarParam.HangarWidth, hangarParam.HangarHeight);
                blockName = "FontWallLeft";
                DrawObject((areaPile - bulgingPilesAgainstWall) / 2, areaPile - (areaPile - bulgingPilesAgainstWall) / 2, hangarParam.HeightPiles, bulgingPilesAgainstWall, (hangarParam.HangarWidth - hangarParam.GateWidth - areaPile + (areaPile - bulgingPilesAgainstWall)) / 2, hangarParam.WallHeight);
                blockName = "FontWallRigth";
                DrawObject((areaPile - bulgingPilesAgainstWall) / 2, areaPile - (areaPile - bulgingPilesAgainstWall) / 2 + (hangarParam.HangarWidth - hangarParam.GateWidth - areaPile + (areaPile - bulgingPilesAgainstWall)) / 2 + hangarParam.GateWidth, hangarParam.HeightPiles, bulgingPilesAgainstWall, (hangarParam.HangarWidth - hangarParam.GateWidth) / 2, hangarParam.WallHeight);
                blockName = "Gate";
                DrawObject(areaPile / 2, (areaPile + hangarParam.HangarWidth - hangarParam.GateWidth) / 2, hangarParam.HeightPiles + hangarParam.WallHeight, 0, hangarParam.GateWidth, hangarParam.GateHeight);
                blockName = "BackWall";
                DrawObject((areaPile - bulgingPilesAgainstWall) / 2 + hangarParam.HangarLength, (areaPile - bulgingPilesAgainstWall) / 2 + bulgingPilesAgainstWall, hangarParam.HeightPiles, bulgingPilesAgainstWall, hangarParam.HangarWidth - bulgingPilesAgainstWall, hangarParam.WallHeight);
                blockName = "Roof";
                DrawObject(0, (hangarParam.HangarWidth + areaPile) / 2, hangarParam.HeightPiles + hangarParam.WallHeight + hangarParam.HangarHeight, hangarParam.HangarLength + areaPile, hangarParam.HangarWidth, 0);

                //Внутренний метод DrawHangar-а, который создаёт объект по заданным координатам и размерам.
                void DrawObject(double x, double y, double z, double length, double width, double height)
                {
                    doc.LockDocument();
                    BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                    if (bt.Has(blockName))
                    {
                        ed.WriteMessage("\nA block with the name \"" + blockName + "\" already exists.");
                        return;
                    }
                    BlockTableRecord btr = new BlockTableRecord();
                    btr.Name = blockName;
                    ObjectId btrId = bt.Add(btr);
                    tr.AddNewlyCreatedDBObject(btr, true);
                    Polyline3d acPoly3d = new Polyline3d();
                    acPoly3d.ColorIndex = 5;
                    btr.AppendEntity(acPoly3d);
                    tr.AddNewlyCreatedDBObject(acPoly3d, true);
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
                    BlockTableRecord ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                    BlockReference br = new BlockReference(Point3d.Origin, btrId);
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
                        roof.Add(new Point3d(x + length, y, z + Math.Sqrt(width * width / 12)));
                        return roof;
                    }
                }
                tr.Commit();
            }
        }
    }
}
