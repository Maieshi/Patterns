using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace forms
{
    public partial class Form1 : Form
    {
        Figure currentF;
        Graphics gr;
        List<Figure> figures = new List<Figure>();
        List<FigureCreator> figC = new List<FigureCreator>(); //figureCreator

        Color color = Color.Black;

        //const int width = 50;
        //const int height = 50;
        bool isClick = false;
        bool isShift = false;
        bool isGroup;

        char flag = 'G';
        Point firstp;

        Point Spawnpoint;

        
        Manipulator manipulator;
        Group group;
        Manipulator.PrototypeM PM;
        Group.PrototypeG PG;

        Facade facade;

        Context context;
        public Form1()
        {
            InitializeComponent();
            gr = panel1.CreateGraphics();
            //manipulator = new Manipulator();
            manipulator = Manipulator.getInstance();
            //manipulator.SetNull();

            group = Group.getInstance();
            

            PM = new Manipulator.PrototypeM();
            PM.manipulator = Manipulator.getInstance();

            PG = new Group.PrototypeG();
            PG.group = Group.getInstance();

            

            context = new Context(manipulator);

            facade = new Facade(group,manipulator);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isClick = false;
            foreach (Figure f in figures)
                f.click = false;


            if (flag == 'R')
            {
                /*currentF = rc.Create(firstp.X, firstp.Y, e.X, e.Y, Color.Red); */
                //new Rectangle(firstp.X, firstp.Y,  e.X, e.Y, Color.Red); 
                var rc = new Rectangle.RectCreator();
                currentF = rc.Create(firstp.X, firstp.Y, e.X, e.Y, Color.Red);


                figC.Add(rc);
                figures.Add(currentF);
                currentF.Draw(gr);
            }

            if (flag == 'T')
            {
                // currentF = new Triangle(firstp.X, firstp.Y, e.X, e.Y, Color.Green);

                var rc = new Triangle.TrianCreator();
                currentF = rc.Create(firstp.X, firstp.Y, e.X, e.Y, Color.Green);

                figures.Add(currentF);
                figC.Add(rc);
                currentF.Draw(gr);
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            flag = 'T';
        }

        private void circkle_CheckedChanged(object sender, EventArgs e)
        {
            flag = 'R';
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            panel1.Refresh();


            firstp = e.Location;


            if (flag == 'T' || flag == 'R')
            {
                firstp = e.Location;
                //label1.Text = flag.ToString();
            }
            else if (flag == 'M') //если манипулятор
            {
                context.strategy = manipulator;
                if (manipulator.CurrentFig == null || !manipulator.Click(e.Location)
                ) //нету фигуры в манипуляторе или не попали
                {
                    isClick = false;

                    foreach (Figure f in figures) // проверить другие фигуры 
                        if (f.Click(e.Location))
                        {
                            manipulator.Attach(f);
                            isClick = true;
                        }

                    if (isClick) //если среди других фигура выюрана
                    {
                        //manipulator.Delta(out manipulator.dx,out manipulator.dx1,out manipulator.dy,out manipulator.dy1, firstp);
                        facade.FDeltaManipulator(firstp);
                        manipulator.Draw(gr);
                    }
                    else //фигрура среди других не выбрана
                    {
                        //label1.Text += "@";

                        manipulator.SetNull(); //убрать выделение с текущей фигуры
                        panel1.Refresh(); //убрать отрисовку выделения
                    }
                }
                else //попали в текущую фигуру манипулятора
                {
                    //  if (strategy.Click(e.Location)) //попали в корнер
                    //  {
                    //manipulator.Delta(out manipulator.dx, out manipulator.dx1, out manipulator.dy, out manipulator.dy1, firstp);
                    facade.FDeltaManipulator(firstp);
                    manipulator.Draw(gr);
                    isClick = true;
                    //  }
                }
            }
            else // если выбрали group
            {
                context.strategy = group;
                group.lastX = group.x;
                group.lastY = group.y;
                group.lastW = group.width;
                group.lastH = group.height;
                
                if (group.Click(e.Location) && group.figures.Count > 0) // попали в корнер группировщика и есть фигуры в списке
                {
                    //group.Delta(out group.dx, out group.dx1, out group.dy, out group.dy1, e.Location);
                    facade.FDeltaGroup(e.Location);
                    //label1.Text = " dx:" + group.dx + " dy:" + group.dy + " dx1:" + group.dx1 + " dy1:" + group.dy1 + " e:" + e.Location+ " x:"+group.x+" y:"+group.y+" w:"+ group.width+" h:"+ group.height+" fx:"+group.figures[0].x+" fy:"+ group.figures[0].y + " fw:" + group.figures[0].width + " fh:" + group.figures[0].height;
                    group.Draw(gr);
                    isClick = true;
                }
                else
                {
                    Figure temp = null;
                    foreach (Figure f in figures) // проверка на попадание фигуры
                        if (f.Click(e.Location))
                        {
                            temp = f;
                        }

                    if (temp != null) //попали в фигуру
                    {
                        if (isShift) //зажата клавиша s
                        {
                            if (group.figures.Contains(temp)) //фигура есть в списке
                            {
                                group.Update(temp); //удалить фигуру из списка
                                group.Draw(gr);
                            }
                            else //фигуры нет в списке
                            {
                                group.Add(temp); //   добавить в список фигуру
                                group.Draw(gr);
                            }
                        }
                        else //shift  не зажата
                        {
                            group.Clear(); // очистить список и добавить в него фигуру
                            group.Add(temp);
                            group.Draw(gr);
                        }
                    }
                    else //не попали в фигуру
                    {
                        group.Clear();
                    }
                }

                group.copyList();
            }
        }


        private void Move_CheckedChanged(object sender, EventArgs e)
        {
            flag = 'P';
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            Spawnpoint = e.Location;

            //label1.Text = "move";
            if (e.Button == MouseButtons.Left)
            {
                if (isClick)
                {
                    if (flag == 'M')
                    {
                         
                        if (manipulator.corner == 4)
                        {
                            panel1.Refresh();
                            manipulator.Move(e.Location);
                            manipulator.Draw(gr);
                        }
                        else if (manipulator.corner >= 0 && manipulator.corner <= 3)
                        {
                            panel1.Refresh();
                            context.Smena(e.Location);
                            manipulator.Draw(gr);
                        }
                    }
                    else if (flag == 'G')
                    {
                       
                        if (group.corner == 4)
                        {
                            panel1.Refresh();
                            group.Move(e.Location);
                            group.Draw(gr);
                        }
                        else if (group.corner >= 0 && group.corner <= 3)
                        {
                            panel1.Refresh();
                            context.Smena(e.Location);
                            group.Draw(gr);
                        }
                    }
                }
                else
                {
                    if (flag == 'R')
                    {
                        panel1.Refresh();

                        var rc = new Rectangle.RectCreator();
                        currentF = rc.Create(firstp.X, firstp.Y, e.X, e.Y, Color.Red);
                        currentF.DrawCur(gr);
                    }

                    if (flag == 'T')
                    {
                        panel1.Refresh();
                        //currentF = new Triangle(firstp.X, firstp.Y, e.X, e.Y, Color.Green);
                        var rc = new Triangle.TrianCreator();
                        currentF = rc.Create(firstp.X, firstp.Y, e.X, e.Y, Color.Green);

                        currentF.DrawCur(gr);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure f in figures)
            {
                f.Draw(gr);
            }
        }

        private void Resize_CheckedChanged(object sender, EventArgs e)
        {
            flag = 'M';
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char) Keys.S)
            {
                isShift = true;
            }
            else if (e.KeyValue == (char) Keys.C )//копировать
            {
                if(flag =='G')
                {
                    isGroup = true;
                    PG.p = new Point(group.x,group.y);
                    PG.Clone();
                }
                else if(flag =='M')
                {
                    isGroup = false;
                    PM.Clone();
                }
            }
            else if (e.KeyValue == (char) Keys.V && Prototype.copyFigures.Count != 0)//вставить
            {
                if (isGroup) PG.Spawn(Spawnpoint,currentF,figC,figures,gr);
                else  PM.Spawn(Spawnpoint, currentF, figC, figures, gr);
                label1.Text = figures[0].x.ToString();
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char) Keys.S)
            {
                isShift = false;
            }
        }

        private void Group_radio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 'G';
            
        }
    }
}