using System;
using System.Windows.Forms;
using System.Xml;
using FigureLib;

namespace FigurePropertyView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowView(XmlDocument view)
        {
            ParamValues.Controls.Clear();
            int top = 20;
            var rootView = view.DocumentElement;
            XmlNodeList nodeList = rootView.SelectNodes("./control");
            foreach(XmlNode item in nodeList)
            {
                if(item.Attributes["type"].Value == "text")
                {
                    Label lb = new Label();
                    lb.Text = item.Attributes["caption"].Value;
                    lb.Top = top;
                    lb.Left = 10;
                    lb.Width = 50;
                    ParamValues.Controls.Add(lb);

                    TextBox tb = new TextBox();
                    tb.Name = item.Attributes["name"].Value;
                    ParamValues.Controls.Add(tb);
                    tb.Top = top;
                    tb.Left = 70;
                }
                
                top += 20;
            }

        }
        private XmlDocument BuildRequest()
        {
            int paramCount = 1;
            var param = new XmlDocument();
            XmlElement parameters = param.CreateElement("parameters");
            param.AppendChild(parameters);

            foreach(var item in ParamValues.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    XmlNode node = param.CreateElement("param" + paramCount++.ToString());
                    node.AppendChild(param.CreateTextNode(((TextBox)item).Text));
                    parameters.AppendChild(node);

                }
            }
            return param;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var figureManager = new FigureManager();
            
            foreach(var item in figureManager.FigureList)
            {
                FigureList.Items.Add(item);
            }
        }

        private void FigureList_Click(object sender, EventArgs e)
        {

        }

        private void FigureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParamValues.Controls.Clear();
            MethodList.Items.Clear();
            if ( ((ListBox)sender).SelectedItem != null)
            {
                var  figure = ((ListBox)sender).SelectedItem as Figure;
                foreach(var item in figure.functions)
                {
                    MethodList.Items.Add(item);
                }
            }
        }

        private void MethodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
            {
                var act = ((ListBox)sender).SelectedItem as ActionMetnod;
                ShowView(act.View);

            }
        }

        private void btCount_Click(object sender, EventArgs e)
        {
            Figure currentFigure = FigureList.SelectedItem as Figure;
            if (currentFigure == null) return;
            ActionMetnod currentAct = MethodList.SelectedItem as ActionMetnod;
            if (currentAct == null) return;
            tbResult.Text = currentFigure.Execute(currentAct.Name, BuildRequest());

            
        }
    }
}

