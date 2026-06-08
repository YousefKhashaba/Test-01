using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using KarambaUIWidgets.UIWidgets;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace TectumMechanics_MVP1
{
    public partial class TectumMechanics_Test : GH_ExtendableComponent
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public TectumMechanics_Test()
          : base("TectumMechanics_Test", "TectumMechanics_Test",
            "Description",
            "TectumMechanics", "TectumMechanics")
        {
        }


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            //0
            pManager.AddCurveParameter(
                        "Curve(s)/Line(s)",
                        "Curve(s)/Line(s)",
                        "...",
                        GH_ParamAccess.list);

            //Always reparameterized.
            var param = pManager[0] as Grasshopper.Kernel.Parameters.Param_Curve;
            param.Reparameterize = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            //0
            pManager.AddGenericParameter(
            "Points",
            "Points",
            "...",
            GH_ParamAccess.tree);

            //1
            pManager.AddGenericParameter(
"Frames",
"Frames",
"...",
GH_ParamAccess.tree);

            //2
            pManager.AddGenericParameter(
"Breps",
"Breps",
"...",
GH_ParamAccess.tree);

            //3
            pManager.AddGenericParameter(
"Extended Curves",
"Extended Curves",
"...",
GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Curve> Curves = new List<Curve>();

            DA.GetDataList(0, Curves);

            DataTree<Point3d> Points = new DataTree<Point3d>();
            DataTree<Plane> Frames = new DataTree<Plane>();
            DataTree<Brep> Breps = new DataTree<Brep>();


            List<Curve> ExtendedCurves = new List<Curve>();
            //Extend
            for (int i = 0; i < Curves.Count; i++)
            {
                if (BasicMainBox04_RadioButtonsGroup.GetActiveInt()[0] == 1)
                {
                    Curve ExtendedCurve = Curves[i].Extend(CurveEnd.End, BasicMainBox03_Slider02.Value, CurveExtensionStyle.Smooth);
                    ExtendedCurve.Domain = new Interval(0, 1); //Reparametrize the extended curve.
                    ExtendedCurves.Add(ExtendedCurve);
                } else
                {
                    Curve ExtendedCurve = Curves[i].Extend(CurveEnd.Start, BasicMainBox03_Slider02.Value, CurveExtensionStyle.Smooth);
                    ExtendedCurve.Domain = new Interval(0, 1); //Reparametrize the extended curve.
                    ExtendedCurves.Add(ExtendedCurve);
                }

            }


            int SliderValue = (int)BasicMainBox03_Slider01.Value;

            DataTree<double> Parameters = new DataTree<double>();

            for (int i = 0; i < ExtendedCurves.Count; i++)
            {
                double[] _Parameters = ExtendedCurves[i].DivideByCount(SliderValue - 1, true);
                Parameters.AddRange(_Parameters, new GH_Path(i));
            }


            //Points
            for (int i =0; i < ExtendedCurves.Count; i++)
            {
                for (int j = 0; j < Parameters.Branches[i].Count; j++)
                {
                  Points.Add(
                  ExtendedCurves[i].PointAt(Parameters.Branches[i][j]),
                  new GH_Path(i));
                }
            }

            if(Checkbox01.Active) { DA.SetDataTree(0, Points); }

            //Frames
            if (Checkbox02.Active || Checkbox03.Active)
            {
                for (int i = 0; i < ExtendedCurves.Count; i++)
                {
                    for (int j = 0; j < Parameters.Branches[i].Count; j++)
                    {
                        Plane PerpFrame = new Plane();
                        ExtendedCurves[i].PerpendicularFrameAt(Parameters.Branches[i][j], out PerpFrame);
                        Frames.Add(PerpFrame, new GH_Path(i));
                    }
                }
            }

            if (Checkbox02.Active) { DA.SetDataTree(1, Frames);  }

            //Breps
            if (Checkbox03.Active)
            {
                for (int i = 0; i < ExtendedCurves.Count; i++)
                {
                    for (int j = 0; j < Parameters.Branches[i].Count; j++)
                    {
                        Brep MainBrep = new Brep();

                        if(Dropdown01.Value == 0) { MainBrep = new Box(Frames.Branches[i][j], new Interval(-50, 50), new Interval(-50, 50), new Interval(-50, 50)).ToBrep(); }
                        if(Dropdown01.Value == 1) { MainBrep = new Sphere(Points.Branches[i][j], 100).ToBrep(); }
                        if(Dropdown01.Value == 2) { MainBrep = new Cylinder(new Circle(Points.Branches[i][j], 50), 100).ToBrep(true, true); }

                        Breps.Add(MainBrep, new GH_Path(i));
                    }
                }
            }

            if (Checkbox03.Active) { DA.SetDataTree(2, Breps); }

            DA.SetDataList(3, ExtendedCurves);

        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => null;

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("3d0d2659-5813-4346-abe6-62138a8fe0bf");
    }
}