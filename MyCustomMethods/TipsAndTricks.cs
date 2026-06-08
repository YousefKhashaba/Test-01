using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TectumMechanics_MVP1.MyCustomMethods
{
    internal class TipsAndTricks
    {



        //Add this below the parameter in the RegisterInputParams to make the input be reparametrized by default when the component is placed.

        //

        ////Always reparameterized for Curves.
        //var param = pManager[0] as Grasshopper.Kernel.Parameters.Param_Curve;
        //param.Reparameterize = true;

        ////Always reparameterized for Surfaces.
        //var param = pManager[0] as Grasshopper.Kernel.Parameters.Param_Surface;
        //param.Reparameterize = true;


        //


        //Tip #1

        ////When using the 'Extend' method. Always remember to reparametrize the extended curve after using the extend method to be able to use it in other methods.
        
        //ExtendedCurve.Domain = new Interval(0, 1); //Reparametrize the extended curve.

        //Tip #2

        ////Always remember before using transforms to duplicate the geometry into a new variable and then apply the transformation to that new variable to prevent any glitches. 
        
        //Curve OrientedSection = SectionShape.Branches[a][m].DuplicateCurve(); //To prevent glitches.
        //OrientedSection.Transform(xform); //Move/Orient the section shape to the curve's frame.


    }
}
