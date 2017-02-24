using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mid_Point_Circle_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void PutPixel(Graphics g, int x, int y)
        {

            Bitmap bm = new Bitmap(1, 1);

            bm.SetPixel(0, 0, Color.Red);

            g.DrawImageUnscaled(bm, x, y);
          
        }
        void Circle(int Radius, int Xc, int Yc, PaintEventArgs e)
        {
            int P;
            int X, Y;
            P = 1 - Radius;
            X = 0;
            Y = Radius;
            onCirclePoint(X,Y,Xc,Yc,e);
            while (X<=Y)
            {
                X++;
                if (P < 0)
                {
                    P = P+ 2 * X + 1;
                }
                else 
                {
                    P = P + 2 * X + 1 - 2 * Y;
                    Y--;
                }
                onCirclePoint(X, Y, Xc, Yc,e);
            
            }
        
        }

        void onCirclePoint(int x, int y, int Xc, int Yc,PaintEventArgs e) {
            Graphics myGraphics = e.Graphics;
            PutPixel(myGraphics, Xc - x, Yc - y);
            PutPixel(myGraphics, Xc - y, Yc - x);
            PutPixel(myGraphics, Xc + y, Yc - x);
            PutPixel(myGraphics, Xc + x, Yc - y);

            PutPixel(myGraphics, Xc - x, Yc + y);
            PutPixel(myGraphics, Xc - y, Yc + x);
            PutPixel(myGraphics, Xc + y, Yc + x);
            PutPixel(myGraphics, Xc + x, Yc + y);
             
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void MidPointCircle()
        {
            try {
                int Radius;
                int Xc;
                int Yc;
                if (txtx.Text == "")
                {
                    Xc = 200;
                }
                else
                {
                    Xc = Convert.ToInt32(txtx.Text);
                }
                if (txtY.Text == "")
                {
                    Yc = 150;
                }
                else
                {
                    Yc = Convert.ToInt32(txtY.Text);
                }
                if (txtR.Text == "")
                {
                    Radius = 150;
                }
                else
                {
                    Radius = Convert.ToInt32(txtR.Text);
                }
                int K, P, X_2, Y_2;
               
                P = 1 - Radius;


                K = 0;
                listView1.Items.Clear();
                while (Xc <= Yc)
                {
                    X_2 = Xc * 2;
                    Y_2 = Yc * 2;
                    ListViewItem lvi = new ListViewItem(K.ToString());
                    lvi.SubItems.Add(P.ToString());
                    lvi.SubItems.Add("( " + Xc.ToString() + "  ,  " + Yc.ToString() + " )");
                    lvi.SubItems.Add("( " + X_2.ToString() + "  ,  " + Y_2.ToString() + " )");
                    listView1.Items.Add(lvi);
                    if (P < 0)
                    {

                        P = P + (2 * Xc) + 1;
                        Xc = Xc + 1;

                    }
                    else
                    {

                        P = P + 2 * Xc + 1 - 2 * Yc;
                        Xc = Xc + 1;
                        Yc = Yc - 1;
                    }


                    K = K + 1;
                    Xc++;



                }

              
            }catch (Exception ex){
            MessageBox .Show (ex.ToString ());
            }
        }
        void lineBres(int xa, int ya, int xb, int yb, PaintEventArgs e)
        {
            int dx = Math.Abs(xb - xa);
            int dy = Math.Abs(yb - ya);
            int p = 2 * dy - dx;
            int x, y, xe;
            Graphics myGraphics = e.Graphics;

            if (xa > xb)
            {
                x = xb;
                y = yb;
                xe = xa;


            }
            else
            {

                x = xa;
                y = ya;
                xe = xb;
            }
            PutPixel(myGraphics, x, y);
            if (xa == xb)
            {
                if (yb > ya)
                {
                    for (; y <= yb; y++)
                    {
                        PutPixel(myGraphics, x, y);
                    }

                }
                else
                {
                    y = yb;
                    for (; y <= ya; y++)

                        PutPixel(myGraphics, x, y);

                }
            }
            else
            {
                while (x < xe)
                {
                    x++;
                    if (p < 0)
                    {
                        p = p + 2 * dy;

                    }
                    else
                    {
                        y++;
                        p = Math.Abs(p + 2 * (dy - dx));

                    }

                    PutPixel(myGraphics, x, y);

                }

            }


        }

        void BrensnhamLineTable()
        {
            int xa, ya, xb, yb;
            xa = 20;
            ya = 10;
            xb = 30;
            yb = 18;

            int dx = Math.Abs(xb - xa);
            int dy = Math.Abs(yb - ya);
            int p = 2 * dy - dx;
            listView2.Items.Clear();
            for (int M = 0; M < dx; M++)
            {

                xa = xa + 1;
                ListViewItem lvi = new ListViewItem(M.ToString());
                lvi.SubItems.Add(p.ToString());
               
               
                if (p < 0)
                {
                    p = p + 2 * dy;


                }
                else
                {

                    ya = ya + 1;
                    p = p + 2 * dy - 2 * dx;


                }

                lvi.SubItems.Add("( " + xa.ToString() + "  ,  " + ya.ToString() + " )");
                listView2.Items.Add(lvi);

            }


        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
            showCircle(e);
        }
        void showCircle(PaintEventArgs e)
        {
            try {

                int Radius;
                int Xc;
                int Yc;
                if (txtx.Text == "")
                {
                    Xc = 200;
                }
                else
                {
                    Xc = Convert.ToInt32(txtx.Text);
                }
                if (txtY.Text == "")
                {
                    Yc = 150;
                }
                else
                {
                    Yc = Convert.ToInt32(txtY.Text);
                }
                if (txtR.Text == "")
                {
                    Radius = 150;
                }
                else
                {
                    Radius = Convert.ToInt32(txtR.Text);
                }
                Circle(Radius, Xc, Yc, e);
                MidPointCircle();
            }catch (Exception ex){
            MessageBox .Show (ex.ToString ());
            }
            
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            int xa, ya, xb, yb;
            xa = 100;
            ya = 50;
            xb = 300;
            yb = 150;
            lineBres(xa, ya, xb, yb, e);
            BrensnhamLineTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Refresh();
        }
    }
}
