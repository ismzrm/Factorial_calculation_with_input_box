using Microsoft.VisualBasic;
using System.Linq.Expressions;
using System.IO;
using System.Windows.Forms;
namespace ödev_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void faktoriyel(int sayi)
        {
            fakt = 1;
            for(i=1; i<=sayi;i++)
            {
                fakt *= i;
            }
          soru=MessageBox.Show(sayi + "! =" + fakt,"SONUC",MessageBoxButtons.YesNo);
            if(soru==DialogResult.Yes)
            {
                soru2 = MessageBox.Show(sayi + "! =" + fakt+
                    " Hesaplaması bilgiler.txt dosyasına kaydedilsin mi", "SONUC",
                    MessageBoxButtons.YesNo);
                if(soru2==DialogResult.Yes)
                {
                    StreamWriter kaydet =File.AppendText("bilgiler.txt");
                    kaydet.WriteLine(sayi + "! =" + fakt +"  "+ DateTime.Now);
                    kaydet.Close();
                    MessageBox.Show("Bilgiler başarıyla kaydedildi!");

                    StreamReader oku = File.OpenText("bilgiler.txt");
                    while ((sonuc = oku.ReadLine()) != null)
                    {
                        listBox1.Items.Add(sonuc);
                    }
                    oku.Close();
                }
                
            }
        }
        string sonuc;
      
        int sayi,fakt,i;
        DialogResult soru,soru2;

        private void Form1_Load(object sender, EventArgs e)
        {
            Start:
            
             string input =Interaction.InputBox("Sayı Giriniz","Sayı");
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Lütfen 1 ile 10 arasında bir sayi giriniz giriniz");
                goto Start;
            }

            if (int.TryParse(input, out int sayi))
            {
                
                if (sayi >= 1 && sayi <= 10)
                {
                    faktoriyel(sayi);
                     
                }
                else
                {
                    MessageBox.Show("Lütfen 1 ile 10 arasında bir sayı giriniz.");
                    goto Start; 
                }
            }
            else
            {

                MessageBox.Show("Geçerli bir sayı girmeniz gerekmektedir!");
                goto Start;
            }
        }



    }
    }

