using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KoolKit.DataAccess;
using KoolKit.DataAccess.Entities;

namespace KoolKit.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ToolKit ToolKitData;

        public MainWindow()
        {
            InitializeComponent();

            // setup watching of ToolKit Data
            var ToolKitJsonReader = new ToolKitJsonReader(@"C:\path\to\data\file");
            ToolKitJsonReader.Changed += new ToolKitJsonReader.ToolKitDataEventHandler(ToolKitDataChanged);

        }

        private void ToolKitDataChanged(object source, EventArgs e) {
            // Teh ToolKit data changed!!!!!
            ToolKitData = ToolKitJsonReader.ToolKitData;
        }
    }
}
