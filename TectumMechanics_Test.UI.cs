using Grasshopper.Kernel;
using KarambaUIWidgets.UIWidgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TectumMechanics_MVP1
{
    //Overrides the default visual appearance of the component to the Karamba3D library or the class 'GH_ExtendableComponentAttributes'.
    //Supporting exapndable menus, headers, checkboxes, sliders, radio buttons.
    public partial class TectumMechanics_Test
    {
        private MenuDropDown Dropdown01;


        private MenuCheckBox Checkbox01;
        private MenuCheckBox Checkbox02;
        private MenuCheckBox Checkbox03;

        private MenuSlider BasicMainBox03_Slider01;
        private MenuSlider BasicMainBox03_Slider02;

        private MenuRadioButtonGroup BasicMainBox04_RadioButtonsGroup;


        protected override void Setup(GH_ExtendableComponentAttributes attr)
        {
            // UI will be built here

            //Variable types for each UI element.
            //Header Box: 'GH_ExtendableMenu'.
            //Widget Host Box: 'MenuPanel'.
            //Slider Box: 'MenuSlider'.

            //    ██████   ██████  ██   ██     ███    ██  █████  ███    ███ ███████ ███████ 
            //    ██   ██ ██    ██  ██ ██      ████   ██ ██   ██ ████  ████ ██      ██      
            //    ██████  ██    ██   ███       ██ ██  ██ ███████ ██ ████ ██ █████   ███████ 
            //    ██   ██ ██    ██  ██ ██      ██  ██ ██ ██   ██ ██  ██  ██ ██           ██ 
            //    ██████   ██████  ██   ██     ██   ████ ██   ██ ██      ██ ███████ ███████ 
            //                                                                              
            //                                                                              

            //VISUAL BLOCK 01
            string BasicHeaderBox01_Name = "Brep Type";
            string BasicMainBox01_Name = "Select the desired Brep type";

            //VISUAL BLOCK 02

            string BasicHeaderBox02_Name = "Analyze Curve";
            string BasicMainBox02_Name = "Start and End Perp Frames";
            string BasicMainBox02_Checkbox01_Name = "Points";
            string BasicMainBox02_Checkbox02_Name = "Perp Frames";
            string BasicMainBox02_Checkbox03_Name = "Breps";

            //VISUAL BLOCK 03

            string BasicHeaderBox03_Name = "Curve Parameters";
            string BasicMainBox03_Name = "Normalized Curve Parameter | Slider Group";
            string BasicMainBox03_Slider01_Name = "Number of perp frames";
            string BasicMainBox03_Slider02_Name = "Point Position";

            //VISUAL BLOCK 04

            string BasicHeaderBox04_Name = "Curve Extension Side";

            //     ██████  ██████  ███    ██ ████████  █████  ██ ███    ██ ███████ ██████      ██     ██ ██ ██████   ██████  ███████ ████████ ███████ 
            //    ██      ██    ██ ████   ██    ██    ██   ██ ██ ████   ██ ██      ██   ██     ██     ██ ██ ██   ██ ██       ██         ██    ██      
            //    ██      ██    ██ ██ ██  ██    ██    ███████ ██ ██ ██  ██ █████   ██████      ██  █  ██ ██ ██   ██ ██   ███ █████      ██    ███████ 
            //    ██      ██    ██ ██  ██ ██    ██    ██   ██ ██ ██  ██ ██ ██      ██   ██     ██ ███ ██ ██ ██   ██ ██    ██ ██         ██         ██ 
            //     ██████  ██████  ██   ████    ██    ██   ██ ██ ██   ████ ███████ ██   ██      ███ ███  ██ ██████   ██████  ███████    ██    ███████ 
            //                                                                                                                                        
            //                                                                                                                                        

            //Box frames.
            GH_ExtendableMenu BasicHeaderBox01 = new GH_ExtendableMenu(0, BasicHeaderBox01_Name);
            GH_ExtendableMenu BasicHeaderBox02 = new GH_ExtendableMenu(1, BasicHeaderBox02_Name);
            GH_ExtendableMenu BasicHeaderBox03 = new GH_ExtendableMenu(2, BasicHeaderBox03_Name);
            GH_ExtendableMenu BasicHeaderBox04 = new GH_ExtendableMenu(3, BasicHeaderBox04_Name);

            MenuPanel BasicMainBox01 = new MenuPanel(0, BasicMainBox01_Name);
            MenuStaticText BasicMainBox01Description = new MenuStaticText();

            MenuPanel BasicMainBox02 = new MenuPanel(1, BasicMainBox02_Name);

            MenuPanel BasicMainBox03 = new MenuPanel(2, BasicMainBox03_Name);
            MenuStaticText BasicMainBox03_Slider01_Description = new MenuStaticText();
            MenuStaticText BasicMainBox03_Slider02_Description = new MenuStaticText();

            MenuPanel BasicMainBox04 = new MenuPanel(3, BasicHeaderBox04_Name);


            //Define names for every box that will actually RENDER or APPEAR on the component itself.
            BasicHeaderBox01.Name = BasicHeaderBox01_Name; //This is the actual text displayed on the header box.
            BasicHeaderBox02.Name = BasicHeaderBox02_Name;
            BasicHeaderBox03.Name = BasicHeaderBox03_Name;
            BasicHeaderBox04.Name = BasicHeaderBox04_Name;

            //Default state of every box.
            BasicHeaderBox01.Collapse(); //The header box default condition is collapsed.
            BasicHeaderBox02.Collapse();
            BasicHeaderBox03.Collapse();
            BasicHeaderBox04.Collapse();

            //Image
            attr.ThumbnailImage = Properties.Resource1.Dice;

            //    ██ ███    ██ ████████ ███████ ██████   █████   ██████ ████████ ██ ██    ██ ███████     ██     ██ ██ ██████   ██████  ███████ ████████ ███████ 
            //    ██ ████   ██    ██    ██      ██   ██ ██   ██ ██         ██    ██ ██    ██ ██          ██     ██ ██ ██   ██ ██       ██         ██    ██      
            //    ██ ██ ██  ██    ██    █████   ██████  ███████ ██         ██    ██ ██    ██ █████       ██  █  ██ ██ ██   ██ ██   ███ █████      ██    ███████ 
            //    ██ ██  ██ ██    ██    ██      ██   ██ ██   ██ ██         ██    ██  ██  ██  ██          ██ ███ ██ ██ ██   ██ ██    ██ ██         ██         ██ 
            //    ██ ██   ████    ██    ███████ ██   ██ ██   ██  ██████    ██    ██   ████   ███████      ███ ███  ██ ██████   ██████  ███████    ██    ███████ 
            //                                                                                                                                                  
            //                                                                                                                                                  

            //Methods for defining every interactive widget/UI element.
            //Examples include: sliders, radio buttons, checkboxes, dropdown menus.

            //VISUAL BLOCK 01

            BasicMainBox01Description.Text = "Select the desired Brep type:";
            Dropdown01 = new MenuDropDown(0, BasicMainBox01_Name, BasicMainBox01_Name);

            Dropdown01.AddItem("0", "Box");
            Dropdown01.AddItem("0", "Sphere");
            Dropdown01.AddItem("0", "Cylinder");

            //VISUAL BLOCK 02

            Checkbox01 = new MenuCheckBox(0, BasicMainBox02_Checkbox01_Name, BasicMainBox02_Checkbox01_Name); 
            Checkbox02 = new MenuCheckBox(1, BasicMainBox02_Checkbox02_Name, BasicMainBox02_Checkbox02_Name);
            Checkbox03 = new MenuCheckBox(2, BasicMainBox02_Checkbox03_Name, BasicMainBox02_Checkbox03_Name);

            //Default state of checkboxes.
            Checkbox01.Active = false;
            Checkbox02.Active = false;
            Checkbox03.Active = false;

            //VISUAL BLOCK 03

            BasicMainBox03_Slider01_Description.Text = "Number of curve divisions:";

            BasicMainBox03_Slider01 = new MenuSlider(
            0, //Index of the slider. Decides the position of this slider in the list of sliders if any.
            BasicMainBox03_Slider01_Name, //
            1, //Minimum value of the slider.
            50, //Maximum value of the slider.
            25, //Default value of the slider.
            0    //Number of decimal places of the values.
            );

            BasicMainBox03_Slider02_Description.Text = "Extension distance:";

            BasicMainBox03_Slider02 = new MenuSlider(
            1, //Index of the slider. Decides the position of this slider in the list of sliders if any.
            BasicMainBox03_Slider02_Name, //
            0.0, //Minimum value of the slider.
            5000.0, //Maximum value of the slider.
            1500, //Default value of the slider.
            2    //Number of decimal places of the values.
            );

            //VISUAL BLOCK 04

            BasicMainBox04_RadioButtonsGroup = new MenuRadioButtonGroup(3, BasicHeaderBox04_Name);
            BasicMainBox04_RadioButtonsGroup.Direction = MenuRadioButtonGroup.LayoutDirection.Horizontal;
            BasicMainBox04_RadioButtonsGroup.MaxActive = 1;  // only one can be active at a time
            BasicMainBox04_RadioButtonsGroup.MinActive = 1;  // at least one must always be active

            MenuRadioButton BasicMainBox04_RadioButtonsGroup_RadioButton01 = new MenuRadioButton(0, "Curve Start", "Curve Start", MenuRadioButton.Alignment.Vertical);
            MenuRadioButton BasicMainBox04_RadioButtonsGroup_RadioButton02 = new MenuRadioButton(1, "Curve End", "Curve End", MenuRadioButton.Alignment.Vertical);

            BasicMainBox04_RadioButtonsGroup.AddButton(BasicMainBox04_RadioButtonsGroup_RadioButton01);
            BasicMainBox04_RadioButtonsGroup.AddButton(BasicMainBox04_RadioButtonsGroup_RadioButton02);

            BasicMainBox04_RadioButtonsGroup.SetActive(0);

            //    ██████  ███████  ██████  █████  ██       ██████ ██    ██ ██       █████  ████████ ██  ██████  ███    ██ ███████ 
            //    ██   ██ ██      ██      ██   ██ ██      ██      ██    ██ ██      ██   ██    ██    ██ ██    ██ ████   ██ ██      
            //    ██████  █████   ██      ███████ ██      ██      ██    ██ ██      ███████    ██    ██ ██    ██ ██ ██  ██ ███████ 
            //    ██   ██ ██      ██      ██   ██ ██      ██      ██    ██ ██      ██   ██    ██    ██ ██    ██ ██  ██ ██      ██ 
            //    ██   ██ ███████  ██████ ██   ██ ███████  ██████  ██████  ███████ ██   ██    ██    ██  ██████  ██   ████ ███████ 
            //                                                                                                                    
            //                                                                                                                    

            //Recalculate the component scripts in the main CS files everytime the user changes something.

            //VISUAL BLOCK 01
            Dropdown01.ValueChanged += (s, e) => ExpireSolution(true);


            //VISUAL BLOCK 02

            Checkbox01.ValueChanged += (s, e) => ExpireSolution(true);
            Checkbox02.ValueChanged += (s, e) => ExpireSolution(true);
            Checkbox03.ValueChanged += (s, e) => ExpireSolution(true);

            //VISUAL BLOCK 03

            BasicMainBox03_Slider01.ValueChanged += (s, e) => ExpireSolution(true);
            BasicMainBox03_Slider02.ValueChanged += (s, e) => ExpireSolution(true);

            //VISUAL BLOCK 04

            BasicMainBox04_RadioButtonsGroup.ValueChanged += (s, e) => ExpireSolution(true);

            //     █████  ██████  ██████  ██ ███    ██  ██████      ██     ██ ██ ██████   ██████  ███████ ████████ ███████ 
            //    ██   ██ ██   ██ ██   ██ ██ ████   ██ ██           ██     ██ ██ ██   ██ ██       ██         ██    ██      
            //    ███████ ██   ██ ██   ██ ██ ██ ██  ██ ██   ███     ██  █  ██ ██ ██   ██ ██   ███ █████      ██    ███████ 
            //    ██   ██ ██   ██ ██   ██ ██ ██  ██ ██ ██    ██     ██ ███ ██ ██ ██   ██ ██    ██ ██         ██         ██ 
            //    ██   ██ ██████  ██████  ██ ██   ████  ██████       ███ ███  ██ ██████   ██████  ███████    ██    ███████ 
            //                                                                                                             
            //                                                                                                             

            //Adding all widgets/UI elements to the component in a heirarchy. Order matters in how each element is added to the component.

            //VISUAL BLOCK 01

            attr.AddMenu(BasicHeaderBox01);
            BasicHeaderBox01.AddControl(BasicMainBox01);
            BasicMainBox01.AddControl(BasicMainBox01Description);
            BasicMainBox01.AddControl(Dropdown01);

            //VISUAL BLOCK 02
            attr.AddMenu(BasicHeaderBox02);
            BasicHeaderBox02.AddControl(BasicMainBox02);
            BasicMainBox02.AddControl(Checkbox01);
            BasicMainBox02.AddControl(Checkbox02);
            BasicMainBox02.AddControl(Checkbox03);

            //VISUAL BLOCK 03
            attr.AddMenu(BasicHeaderBox03);
            BasicHeaderBox03.AddControl(BasicMainBox03); //Add the main box to the header box.
            BasicMainBox03.AddControl(BasicMainBox03_Slider01_Description);
            BasicMainBox03.AddControl(BasicMainBox03_Slider01); //Add the slider 01 box to the main box.
            BasicMainBox03.AddControl(BasicMainBox03_Slider02_Description);
            BasicMainBox03.AddControl(BasicMainBox03_Slider02); //Add the slider 02 box to the main box.

            //VISUAL BLOCK 04
            attr.AddMenu(BasicHeaderBox04);
            BasicHeaderBox04.AddControl(BasicMainBox04);
            BasicMainBox04.AddControl(BasicMainBox04_RadioButtonsGroup);
        }
    }
}