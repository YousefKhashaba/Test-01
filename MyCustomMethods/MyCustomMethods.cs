using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Render;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyCustomMethods
{

    internal class MyCustomMethods
    {

        //These methods convert a tree input in a component from 'GHStructure' variable type to 'DataTree' variable type.
        //This is in order for the inputs to be used in a unified method inside the SolveInstance method.
        //Because a tree input cannot be set using 'SetData...' directly into a DataTree.
        //Thus, it is first set inside a 'GHStructure' variable type. Then this variable type is converted to 'DataTree' variable type. 

        public static DataTree<string> DataTreeString(GH_Structure<GH_String> GHStructure)
        {
            DataTree<string> DataTree = new DataTree<string>();

            for (int g = 0; g < GHStructure.Branches.Count; g++)
            {
                GH_Path _Path = GHStructure.Paths[g];
                DataTree.EnsurePath(_Path);

                for (int h = 0; h < GHStructure.Branches[g].Count; h++)
                {
                    DataTree.Add(GHStructure.Branches[g][h].Value, _Path);
                }
            }

            return DataTree;
        }

        public static DataTree<Curve> DataTreeCurve(GH_Structure<GH_Curve> GHStructure)
        {
            DataTree<Curve> DataTree = new DataTree<Curve>();

            for (int g = 0; g < GHStructure.Branches.Count; g++)
            {
                GH_Path _Path = GHStructure.Paths[g];
                DataTree.EnsurePath(_Path);

                for (int h = 0; h < GHStructure.Branches[g].Count; h++)
                {
                    DataTree.Add(GHStructure.Branches[g][h].Value, _Path);
                }
            }

            return DataTree;
        }

        public static DataTree<double> DataTreeDouble(GH_Structure<GH_Number> GHStructure)
        {
            DataTree<double> DataTree = new DataTree<double>();

            for (int g = 0; g < GHStructure.Branches.Count; g++)
            {
                GH_Path _Path = GHStructure.Paths[g];
                DataTree.EnsurePath(_Path);

                for (int h = 0; h < GHStructure.Branches[g].Count; h++)
                {
                    DataTree.Add(GHStructure.Branches[g][h].Value, _Path);
                }
            }

            return DataTree;
        }

        public static DataTree<Interval> DataTreeInterval(GH_Structure<GH_Interval> GHStructure)
        {
            DataTree<Interval> DataTree = new DataTree<Interval>();

            for (int g = 0; g < GHStructure.Branches.Count; g++)
            {
                GH_Path _Path = GHStructure.Paths[g];
                DataTree.EnsurePath(_Path);

                for (int h = 0; h < GHStructure.Branches[g].Count; h++)
                {
                    DataTree.Add(GHStructure.Branches[g][h].Value, _Path);
                }
            }

            return DataTree;
        }

        public static DataTree<GH_GeometryGroup> DataTreeGroup(GH_Structure<GH_GeometryGroup> GHStructure)
        {
            DataTree<GH_GeometryGroup> DataTree = new DataTree<GH_GeometryGroup>();

            for (int g = 0; g < GHStructure.Branches.Count; g++)
            {
                GH_Path _Path = GHStructure.Paths[g];
                DataTree.EnsurePath(_Path);

                for (int h = 0; h < GHStructure.Branches[g].Count; h++)
                {
                    DataTree.Add(GHStructure.Branches[g][h], _Path);
                }
            }

            return DataTree;
        }

        //
        //
        //

        //These methods replicate a chosen DataTree to another empty DataTree, placing same number of items, same number of branches using nulls as items.




        //public static DataTree<TOutput> DataTreeReplicateStructure<TInput, TOutput>(DataTree<TInput> OriginalDataTree)
        //{
        //    DataTree<TOutput> DataTree = new DataTree<TOutput>();

        //    for (int g = 0; g < OriginalDataTree.Branches.Count; g++)
        //    {
        //        GH_Path _Path = OriginalDataTree.Paths[g];
        //        DataTree.EnsurePath(_Path);
        //        DataTree.Add(default(TOutput), _Path);
        //    }

        //    return DataTree;
        //}


        public static DataTree<string> DataTreeReplicateStructure_String(DataTree<object> OriginalDataTree)
        {
            DataTree<string> DataTree = new DataTree<string>();

            for (int g = 0; g < OriginalDataTree.Branches.Count; g++)
            {
                GH_Path _Path = OriginalDataTree.Paths[g];
                DataTree.EnsurePath(_Path);
                DataTree.Add(null, _Path);
            }

            return DataTree;
        }

        public static DataTree<double> DataTreeReplicateStructure_Double(DataTree<object> OriginalDataTree)
        {
            DataTree<double> DataTree = new DataTree<double>();

            for (int g = 0; g < OriginalDataTree.Branches.Count; g++)
            {
                GH_Path _Path = OriginalDataTree.Paths[g];
                DataTree.EnsurePath(_Path);
                DataTree.Add(0, _Path);
            }

            return DataTree;
        }

        public static DataTree<Curve> DataTreeReplicateStructure_Curve(DataTree<object> OriginalDataTree)
        {
            DataTree<Curve> DataTree = new DataTree<Curve>();

            for (int g = 0; g < OriginalDataTree.Branches.Count; g++)
            {
                GH_Path _Path = OriginalDataTree.Paths[g];
                DataTree.EnsurePath(_Path);
                DataTree.Add(null, _Path);
            }

            return DataTree;
        }

        public static DataTree<Point3d> DataTreeReplicateStructure_Point3d(DataTree<object> OriginalDataTree)
        {
            DataTree<Point3d> DataTree = new DataTree<Point3d>();

            for (int g = 0; g < OriginalDataTree.Branches.Count; g++)
            {
                GH_Path _Path = OriginalDataTree.Paths[g];
                DataTree.EnsurePath(_Path);
                DataTree.Add(Point3d.Origin, _Path);
            }

            return DataTree;
        }

        //
        //
        //

        public static void RemoveNulls(DataTree<Curve> OriginalDataTree)
        {
            for (int i = 0; i < OriginalDataTree.Branches.Count; i++)
            {
                OriginalDataTree.Branches[i].RemoveAll(x => x == null);
            }
        }
    }

}
