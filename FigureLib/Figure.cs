using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace FigureLib
{
    public abstract class Figure
    {
        public virtual string Name { get { return "Default figure"; } }
        public List<ActionMetnod> functions = new List<ActionMetnod>();
        public virtual string Execute(string funcName, XmlDocument param)
        {

            var item =  functions.Where(value => value.Name == funcName).FirstOrDefault();
            if(item != null && item.Act != null)
            {
                return item.Act(param);
            }
            else
                return "function no found";
        }
        public override string ToString()
        {
            return Name;
        }

    }
    public class Triangle : Figure
    {
        private double SizeA;
        private double SizeB;
        private double SizeC;
        public override string Name { get { return "Треугольник"; } }
        private XmlDocument CreateAreaView()
        {
            var view = new XmlDocument();
            view.LoadXml(
                "<controls>" +
                    "<control type='text' name='param1' caption='a' />" +
                    "<control type='text' name='param2' caption='b' />" +
                    "<control type='text' name='param3' caption='c' />" +
                "</controls>"
                );
            return view;
        }
        private bool CheckValid(double a, double b, double c)
        {
            return !((SizeA + SizeB < SizeC) || (SizeA + SizeC < SizeB) || (SizeB + SizeC < SizeA));

        }
        private bool TryParse(XmlDocument param)
        {
            var root = param.DocumentElement;
            try
            {
                var paramNode = root.SelectSingleNode("param1");
                SizeA = Double.Parse(paramNode.InnerText);
                paramNode = root.SelectSingleNode("param2");
                SizeB = Double.Parse(paramNode.InnerText);
                paramNode = root.SelectSingleNode("param3");
                SizeC = Double.Parse(paramNode.InnerText);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    
        public string Area(XmlDocument param)
        {
            double p;
            if (TryParse(param))
            {
                if (!CheckValid(SizeA, SizeB, SizeC))
                {
                    return "Треугольника с такими сторонами не существует";
                }
                else
                {
                    p = (SizeA + SizeB + SizeC) / 2;
                    return Math.Sqrt(p * (p - SizeA) * (p - SizeB) * (p - SizeC)).ToString();
                }
                
            }
            else
                return "Ошибка парсинга";
            
        }
        public string RightTriangle(XmlDocument param)
        {
            if (TryParse(param))
            {
                if (!CheckValid(SizeA, SizeB, SizeC))
                {
                    return "Треугольника с такими сторонами не существует";
                }
                else
                {
                    if ((SizeA * SizeA == SizeB * SizeB + SizeC * SizeC) || (SizeB * SizeB == SizeA * SizeA + SizeC * SizeC) ||
                        (SizeC * SizeC == SizeA * SizeA + SizeB * SizeB))
                        return "Тругольник прямоугольный";
                    else
                        return "Тругольник не является прямоугольныим";

                }

            }
            else
                return "Ошибка парсинга";
        }

        private string Perimeter(XmlDocument param)
        {
            if (TryParse(param))
            {
                if (!CheckValid(SizeA, SizeB, SizeC))
                {
                    return "Треугольника с такими сторонами не существует";
                }
                else
                {
                    return (SizeA + SizeB + SizeC).ToString();
                }

            }
            else
                return "Ошибка парсинга";
        }
        public Triangle()
        {
            functions.Add(new ActionMetnod("Area", Area, "Площадь", CreateAreaView()));
            functions.Add(new ActionMetnod("RightTriangle", RightTriangle, "Проверка на прямоугольность", CreateRightTriangleView()));
            functions.Add(new ActionMetnod("Primeter", Perimeter, "Периметр", CreatePerimeterView()));
        }

        private XmlDocument CreatePerimeterView()
        {
            return CreateAreaView();
        }

        private XmlDocument CreateRightTriangleView()
        {
            return CreateAreaView();
        }
    }
    public class Circle: Figure
    {
        private double radius;
        private XmlDocument CreateAreaView()
        {
            var view = new XmlDocument();
            view.LoadXml(
                "<controls>" +
                    "<control type='text' name='param1' caption='радиус' />" +
                "</controls>"
                );
            return view;
        }
        private XmlDocument CreatePerimeterView()
        {
            return CreateAreaView();
        }
        public override string Name { get { return "Круг"; } }
        public Circle()
        {
            functions.Add(new ActionMetnod("Area", Area, "Площадь", CreateAreaView()));
            functions.Add(new ActionMetnod("Perimeter", Perimeter, "Периметр", CreatePerimeterView()));
        }
        private string Perimeter(XmlDocument param)
        {
            
            var root = param.DocumentElement;
            try
            {
                var paramNode = root.SelectSingleNode("param1");
                radius = Double.Parse(paramNode.InnerText);

                if (radius < 0)
                {
                    return "Радиус не может быть меньше нуля";
                }
                else
                {
                    return (2 * Math.PI * radius).ToString(); 
                }
            }
            catch (Exception)
            {
                return "Ошибка парсинга";
            }
        }
        private string Area(XmlDocument param)
        {
            var root = param.DocumentElement;
            try
            {
                var paramNode = root.SelectSingleNode("param1");
                Double.TryParse(paramNode.InnerText, out radius);

                if (radius < 0)
                {
                    return "Радиус не может быть меньше нуля";
                }
                else
                {
                    return (Math.PI * radius * radius).ToString();
                }
            }
            catch(Exception)
            {
                return "Ошибка парсинга";
            }
        }
    }
    public class ActionMetnod
    {
        public string Name;
        public Func<XmlDocument, string> Act;
        public string Caption;
        public XmlDocument View;
        public ActionMetnod(string name, Func<XmlDocument, string> act, string caption, XmlDocument view)
        {
            Name = name;
            Act = act;
            Caption = caption;
            View = view;
        }
        public override string ToString()
        {
            return Caption;
        }
    }
    class Rectangle: Figure
    {
        public override string Name { get { return "Прямоугольник"; } }
        public Rectangle()
        {
            functions.Add(new ActionMetnod("Area", Area, "Площадь", CreateAreaView()));
        }

        private XmlDocument CreateAreaView()
        {
            var view = new XmlDocument();
            view.LoadXml(
                "<controls>" +
                    "<control type='text' name='param1' caption='a' />" +
                    "<control type='text' name='param2' caption='b' />" +
                    "<control type='text' name='param3' caption='c' />" +
                    "<control type='text' name='param4' caption='d' />" +
                "</controls>"
                );
            return view;
        }

        private string Area(XmlDocument arg)
        {
            return "без реализации";
        }
    }
    public class FigureManager
    {
        public List<Figure> FigureList = new List<Figure>();
        public FigureManager()
        {
            FigureList.Add(new Triangle());
            FigureList.Add(new Circle());
            FigureList.Add(new Rectangle());
        }
        
    }
}
