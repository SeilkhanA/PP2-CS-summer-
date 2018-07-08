using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form       //разбитиe класса                 //Возможно создать код, который использует эти классы без необходимости редактировать файлы, которые создает Visual Studio.
    {
        Graphics grfx;
        Bitmap bmp;
        Point prevPoint;
        Point currentPoint;
        Pen pen;

        Size bmpSize;
        

        public Form1()                                 //Bitmap объект, используемый для работы с изображениями, определяемыми данными пикселей.
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);        // ссылка на созд Битмапа, считывающий высоту и ширину пикч бокса
            pictureBox1.Image = bmp;                                        //Возвращает или задает изображение, отображаемое по PictureBox
            grfx = Graphics.FromImage(bmp);                                 //Создает новый объект Graphics из указанного объекта Image.
            pen = new Pen(Color.Blue, 7);                                          // ссылка на созд ручки (цвет, толщина)
            grfx.Clear(Color.White);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;                      //округленное начало ручки 
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;                        //округленный конец ручки 
            grfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;      // чтобы не было погрешностей(пустых мест при рисовании ручкой)
            

            InitializeComponent();
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)             // при нажатии на мышку запоминает его местоположение
        {
            prevPoint = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //grfx.DrawLine(pen, prevPoint, currentPoint);                                //при поднятии кнопки мышки рисует линию
            //gfx.DrawRectangle(p, GetRectangle(prevPoint, curPoint));
        }
        

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)               // при движении мышки
        {
            if (e.Button == MouseButtons.Left)                                            //  если зажимаем левую кнопку мыши
            {
                currentPoint = e.Location;                                               // нынешнее состояние мышки стнаовится последним запомнившимся
                pictureBox1.Refresh();                               // ??

                grfx.DrawLine(pen, prevPoint, currentPoint);                          // рисуем пэном
                prevPoint = currentPoint;                            // ??
            }

            toolStripStatusLabel1.Text = e.Location.ToString();     // фиксирует состяние мышки
        }
        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           // e.Graphics.DrawLine(pen, prevPoint, surrentPoint);
            //e.Graphics.DrawRectangle(p, GetRectangle(prevPoint, curPoint));
        }
        private Rectangle GetRectangle(Point p1, Point p2)            // как будет создаваться и расти прямоугольник
        {
            Rectangle res = new Rectangle(Math.Min(p1.X, p2.X),
                                          Math.Min(p1.Y, p2.Y),
                                          Math.Abs(p1.X - p2.X),
                                          Math.Abs(p1.Y - p2.Y));

            return res;
        }




        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)               //сохранение
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)                          //если оказывается окно с информацией сохранения файла
            {
                bmp.Save(saveFileDialog1.FileName);                    // сохранить файл посредством ввода имени и расширения (jpg)
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)             // открывание файла
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)                        //если оказывается окно с информацией открывания файла
            {
                bmp = (Bitmap)Image.FromFile(openFileDialog1.FileName);    // открыть файл посредством выбора или ввода имени (поиск)
                pictureBox1.Image = bmp;                                   //??
                grfx = Graphics.FromImage(bmp);                            //??
            }
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)            // выбор цвета
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) 
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
