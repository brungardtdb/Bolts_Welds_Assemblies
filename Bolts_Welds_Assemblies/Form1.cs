using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Tekla Structures Namespaces
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using TSMUI = Tekla.Structures.Model.UI;
using System.Collections;

namespace Bolts_Welds_Assemblies
{
    public partial class frm_Bolts_Welds_Assemblies : Form
    {
        Model currentModel;

        public frm_Bolts_Welds_Assemblies()
        {
            InitializeComponent();
        }

        private void frm_Bolts_Welds_Assemblies_Load(object sender, EventArgs e)
        {
            // try connecting to model
            try
            {
                currentModel = new Model();
            }
            catch
            {
                MessageBox.Show("Model may not be connected.");
            }
        }

        private void btn_Bolt_Click(object sender, EventArgs e)
        {
            // Current Workplane. Remember how the user had the model before you made changes
            TransformationPlane originalPlane = currentModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();

            TSMUI.Picker thisPicker = new TSMUI.Picker();
            Part firstPickedPart = null;
            Part secondPickedPart = null;

            try
            {
                firstPickedPart = thisPicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as Part;
                secondPickedPart = thisPicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as Part;
            }
            catch
            {
                firstPickedPart = null;
                secondPickedPart = null;
            }

            if (firstPickedPart != null && secondPickedPart != null)
            {
                // Change the workplane to the coordinate system of hte part
                currentModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(firstPickedPart.GetCoordinateSystem()));

                // BOltGroupCode
                BoltArray newBoltArray = new BoltArray();
                newBoltArray.BoltSize = 25.4;
                newBoltArray.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
                newBoltArray.BoltStandard = "A325N";
                newBoltArray.CutLength = 150;
                // Adds to spacings of bolts in X direction
                newBoltArray.AddBoltDistX(76.2);
                newBoltArray.AddBoltDistX(76.2);
                // Only one row of bolts
                newBoltArray.AddBoltDistY(0);
                // Edge distance from first pooint picked to first bolt in x direction
                newBoltArray.StartPointOffset.Dx = 38.1;
                // Front lines up nicely with x / y position in current workplane.
                newBoltArray.Position.Rotation = Position.RotationEnum.FRONT;
                newBoltArray.PartToBoltTo = firstPickedPart;
                newBoltArray.PartToBeBolted = secondPickedPart;
                newBoltArray.FirstPosition = new T3D.Point(0, 100, 0);
                newBoltArray.SecondPosition = new T3D.Point(1000, 250, 0);

                if (newBoltArray.Insert())
                {
                    // Draw X Axis of bolt group
                    TSMUI.GraphicsDrawer thisDrawer = new TSMUI.GraphicsDrawer();
                    thisDrawer.DrawLineSegment(new T3D.LineSegment(newBoltArray.FirstPosition, newBoltArray.SecondPosition), new TSMUI.Color(1, 0, 0));

                    // Set workplane back to what user had before
                    currentModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(originalPlane);

                    // Show the bolt group in the model but the user will never see the workplane change.
                    currentModel.CommitChanges();
                }
                else
                {

                }
            }            

        }

        private void btn_Weld_Click(object sender, EventArgs e)
        {
            TSMUI.Picker thisPicker = new TSMUI.Picker();
            Part firstPickedPart = null;
            Part secondPickedPart = null;

            try
            {
                firstPickedPart = thisPicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as Part;
                secondPickedPart = thisPicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as Part;
            }
            catch 
            {
                firstPickedPart = null;
                secondPickedPart = null;
            }

            if(firstPickedPart != null && secondPickedPart != null)
            {
                Weld newWeld = new Weld();
                newWeld.MainObject = firstPickedPart;
                newWeld.SecondaryObject = secondPickedPart;
                newWeld.SizeBelow = 6.35;
                newWeld.TypeBelow = BaseWeld.WeldTypeEnum.WELD_TYPE_FILLET;
                newWeld.SizeAbove = 0.0;
                newWeld.TypeAbove = BaseWeld.WeldTypeEnum.WELD_TYPE_NONE;
                newWeld.AroundWeld = false;
                newWeld.ShopWeld = true;
                newWeld.ReferenceText = "Typ.";
                newWeld.Placement = BaseWeld.WeldPlacementTypeEnum.PLACEMENT_AUTO;

                if (newWeld.Insert())
                {
                    // Show the weld in the model but the user will never see the workplane chage
                    currentModel.CommitChanges();
                }
                else
                {
                    Tekla.Structures.Model.Operations.Operation.DisplayPrompt("Weld  was not created");
                }
            }
        }

        private void btn_Add_To_Click(object sender, EventArgs e)
        {
            TSMUI.Picker thisPicker = new TSMUI.Picker();
            Part firstPickedPart = null;
            Part secondPickedPart = null;

            try
            {
                firstPickedPart = thisPicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as Part;
                secondPickedPart = thisPicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as Part;
            }
            catch
            {
                firstPickedPart = null;
                secondPickedPart = null;
            }

            if (firstPickedPart != null && secondPickedPart != null)
            {
                Assembly mainAssembly = firstPickedPart.GetAssembly();
                mainAssembly.Add(secondPickedPart);
                mainAssembly.Modify();
                currentModel.CommitChanges();
            }
            else
            {
                Tekla.Structures.Model.Operations.Operation.DisplayPrompt("Could not add parts to assembly");
            }
        }

        private void btn_Get_Assembly_Click(object sender, EventArgs e)
        {
            TSMUI.Picker thisPicker = new TSMUI.Picker();
            Part pickedPart = null;

            try
            {
                pickedPart = thisPicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as Part;
            }
            catch
            {
                pickedPart = null;
            }

            if (pickedPart!= null)
            {
                Assembly thisAssembly = pickedPart.GetAssembly();
                ModelObject mainObject = thisAssembly.GetMainPart();
                Part mainPart = mainObject as Part;
                
                if (mainPart != null)
                {
                    mainPart.Class = "2";
                    mainPart.Modify();
                    // Don't grab from assembly because it doesn't have one...
                    mainPart.GetCoordinateSystem();

                    // Set the mainPart of the assembly.
                    // thisAssembly.setMainPart(pickedPart);

                }
                else
                {
                    Assembly mainAssembly = mainObject as Assembly;
                    if (mainAssembly != null)
                    {
                        // You got an assembly...
                    }
                }

                // This doesn't do anything, don't use it
                ModelObjectEnumerator partsOnAssembly = thisAssembly.GetChildren();
                int childrenObjects = partsOnAssembly.GetSize();

                // Gets Parts
                ArrayList partsList = thisAssembly.GetSecondaries();

                foreach(Part thisPart in partsList)
                {
                    thisPart.Class = "6";
                    thisPart.Modify();
                }

                // Neat way to highlight / select objects in the model.
                TSMUI.ModelObjectSelector selector = new TSMUI.ModelObjectSelector();
                selector.Select(partsList);

                // Gets Sub Assemblies
                int subAssemblies = thisAssembly.GetSubAssemblies().Count;
                Tekla.Structures.Model.Operations.Operation.DisplayPrompt(childrenObjects + " Children Objects");

                currentModel.CommitChanges();
            }
        }

        private void btn_Set_Workplane_Click(object sender, EventArgs e)
        {
            // Reset workplane back to global
            currentModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());

            TSMUI.Picker currentPicker = new TSMUI.Picker();
            Part pickedPart = null;

            try
            {
                pickedPart = currentPicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as Part;
            }
            catch
            {

                pickedPart = null;
            }

            if (pickedPart != null)
            {
                // Change the workplane to the coordinate system of the plate
                currentModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(pickedPart.GetCoordinateSystem()));

                // Show the plate in the model and the workplane change
                currentModel.CommitChanges();

            }
        }
    }
}
