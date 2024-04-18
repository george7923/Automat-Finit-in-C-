using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automat1
{
    public partial class Form1 : Form
    {
        private String st_initiala = "q0";
        private String[] st_finala;
        private ListaTranzitii lista;
        private String CuvantAnalizat;
        private int ContorAntiSpatii;
        private int CapacitateAutomat;
        private List<int> indexulStarilor;
        private List<String> output;
        private List<String> totalstari,st_f;
        private List<Tranzitie> u = new List<Tranzitie>();
        private List<Tranzitie> a = new List<Tranzitie>();
        public List<String> erori = new List<String>();
        private List<bool> ER = new List<bool>();


        public Form1()
        {
            lista = new ListaTranzitii();
            indexulStarilor = new List<int>();
            ContorAntiSpatii = 0;
            CapacitateAutomat = 0;
            output = new List<String>();
            totalstari = new List<String>();
            st_f = new List<String>();
            a = lista.ReturnLista();
            
            


            try
            {
                using (StreamReader sr = new StreamReader("Automat.txt"))
                {
                    this.st_initiala = sr.ReadLine();
                    ER.Add(Regex.IsMatch(st_initiala, "q([1-9][0-9]*|0)"));
                    if (!Regex.IsMatch(st_initiala, "q([1-9][0-9]*|0)"))
                    {

                        erori.Add("Starea intiala nu este acceptata!");


                    }
                    String sf = sr.ReadLine();
                    
                    ER.Add(Regex.IsMatch(sf, "q([1-9][0-9]*|0)"));
                    if (!Regex.IsMatch(sf, "q([1-9][0-9]*|0)"))
                    {

                     erori.Add("Starile finale nu sunt acceptate!");
                    }
                    
                    this.st_finala = sf.Split(' ');
                    for(int i = 0; i< this.st_finala.Length; i++)
                    {
                        if (!Regex.IsMatch(this.st_finala[i], "q([1-9][0-9]*|0)"))
                        {
                            erori.Add("Starile finale nu sunt acceptate!");
                        }
                    }
                    for(int i = 0;i<this.st_initiala.Length;i++)
                    {
                        st_f.Add(st_finala[i]);
                    }

                   
                    while (true)
                    {
                        String linie = sr.ReadLine();
                       
                        String[] elems;
                        if (linie != null)
                        {
                            ER.Add(Regex.IsMatch(linie, "q([1-9][0-9]*|0) [a-zA-Z] q([1-9][0-9]*|0) [a-zA-Z\\\\s]+"));
                            if (!Regex.IsMatch(linie, "q([1-9][0-9]*|0) [a-zA-Z] q([1-9][0-9]*|0) [a-zA-Z\\\\s]+"))
                            {

                                erori.Add("Tranzitia " + linie + " nu este acceptata!");
                            }
                            elems = linie.Split(' ');
                        }
                        else
                        {
                            break;
                        }
                        Tranzitie tr = new Tranzitie(elems[0], elems[1][0], elems[2], elems[3]);
                        
                        
                        
                        
                        this.lista.AdaugaTranzitie(tr);
                        totalstari.Add(elems[0]);
                        totalstari.Add(elems[2]);
                        
                        
                        CapacitateAutomat++;




                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ceva nu a mers bine "+ex.Message);
            }
            InitializeComponent();

          
        }
        


       
        public bool AnalizeazaCuvant(String sir)
        {
            
                
            sir = sir.Replace(" ", "");

            if (sir != "")
            {
                char[] Analiza = sir.ToCharArray();
                String inceput = st_initiala;
                Tranzitie m;

                for(int i = 0; i < Analiza.Length; i++)
                {
                    m = lista.findTranzitie(inceput, Analiza[i]);
                    if(m != null)
                    {
                        inceput = m.getStareFinala();
                        output.Add(m.getOutput());
                    }
                    else
                    {
                        return false;
                    }
                    

                }
                return inceput == st_finala[st_finala.Length - 1];
                

            }
            else
            {
                return false;
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Afiseaza;
            CuvantAnalizat = textBox1.Text;
            button1.Enabled = false;
            for(int i = 0; i < ER.Count(); i++)
            {
                MessageBox.Show(ER[i].ToString());
                
                
            }
            
            if (erori.Count() == 0)
            {
                if (AnalizeazaCuvant(CuvantAnalizat) == true)
                {

                    Afiseaza = String.Concat(output);

                    label2.Text = "Cuvantul este bun! " + Afiseaza;


                }
                else
                {
                    label2.Text = "Cuvantul nu este acceptat de catre automat! ";

                }
            }
            else
            {
                label2.Text = "Automatul nu a putut fi citit!";
                for(int i = 0; i < erori.Count(); i++)
                {
                    MessageBox.Show(erori[i]);
                }
                
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CuvantAnalizat = null;
            MessageBox.Show("Va rog introduceti alt cuvant!");
            label2.Text = "-";
            textBox1.Text = "";
            button1.Enabled = true;
        }
    }
}
