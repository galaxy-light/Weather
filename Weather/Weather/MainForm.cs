using MaterialSkin.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Weather
{
    public partial class MainForm : MetroForm
    {
        string url = "http://www.kma.go.kr/weather/forecast/mid-term-xml.jsp";
        string city = "";
        static double avg;

        Label[,] labelArray;

        public MainForm()
        {
            InitializeComponent();

            comboBox_city.SelectedIndex = 0;            
            label_nowday.Text = "오늘은 "+ DateTime.Now.ToString("yyyy-MM-dd") + " 입니다.";

            Initializelabel();

            strtext();

            // 라벨을 클릭해도 버튼 클릭 이벤트와 동일하게 동작하기 위해서 일단 2차원 배열을 만듦
            labelArray = new Label[,] {
                { label_day1, label_low1, label_high1, label_weather_text1, label_low_text1, label_high_text1, label1, label2 },
                { label_day2, label_low2, label_high2, label_weather_text2, label_low_text2, label_high_text2, label3, label4},
                { label_day3, label_low3, label_high3, label_weather_text3, label_low_text3, label_high_text3, label5, label6},
                { label_day4, label_low4, label_high4, label_weather_text4, label_low_text4, label_high_text4, label7, label8 },
                { label_day5, label_low5, label_high5, label_weather_text5, label_low_text5, label_high_text5, label9, label10 },
                { label_day6, label_low6, label_high6, label_weather_text6, label_low_text6, label_high_text6, label11, label12 }
            };

            for (int i = 0; i < labelArray.GetLength(0); i++) // 행
            {
                for (int j = 0; j < labelArray.GetLength(1); j++) // 그 행 안에 몇 개가 있는지
                {
                    switch (i + 1)
                    {
                        case 1:
                            labelArray[i, j].Click += panel1_Click; // button1_Click 이벤트
                            labelArray[i, j].MouseHover += panel1_MouseHover;
                            labelArray[i, j].MouseMove += panel1_MouseMove;
                            labelArray[i, j].MouseLeave += panel1_MouseLeave;
                            break;

                        case 2:
                            labelArray[i, j].Click += panel2_Click;
                            labelArray[i, j].MouseHover += panel2_MouseHover;
                            labelArray[i, j].MouseMove += panel2_MouseMove;
                            labelArray[i, j].MouseLeave += panel2_MouseLeave;
                            break;                    
                                                      
                        case 3:                       
                            labelArray[i, j].Click += panel3_Click;
                            labelArray[i, j].MouseHover += panel3_MouseHover;
                            labelArray[i, j].MouseMove += panel3_MouseMove;
                            labelArray[i, j].MouseLeave += panel3_MouseLeave;
                            break;                    
                                                      
                        case 4:                       
                            labelArray[i, j].Click += panel4_Click;
                            labelArray[i, j].MouseHover += panel4_MouseHover;
                            labelArray[i, j].MouseMove += panel4_MouseMove;
                            labelArray[i, j].MouseLeave += panel4_MouseLeave;
                            break;                    
                                                      
                        case 5:                       
                            labelArray[i, j].Click += panel5_Click;
                            labelArray[i, j].MouseHover += panel5_MouseHover;
                            labelArray[i, j].MouseMove += panel5_MouseMove;
                            labelArray[i, j].MouseLeave += panel5_MouseLeave;
                            break; 
                            
                        case 6:                       
                            labelArray[i, j].Click += panel6_Click;
                            labelArray[i, j].MouseHover += panel6_MouseHover;
                            labelArray[i, j].MouseMove += panel6_MouseMove;
                            labelArray[i, j].MouseLeave += panel6_MouseLeave;
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void resetpic()
        {
            Thread.Sleep(50); // Thread 없으면 너무 버벅거림

            // 콤보 박스를 리셋했을 때 이미지 초기화
            pictureBox1.Load("../../../../sea-2755908_19203.jpg");
        }

        // 참고
        private void label_click(object sender, EventArgs e)
        {            
            //button1.PerformClick(); //버튼1을 강제로 클릭하게 하는 함수
        }

        public void Initializelabel()
        {
            label1.Text = "℃";
            label2.Text = "℃";
            label3.Text = "℃";
            label4.Text = "℃";
            label5.Text = "℃";
            label6.Text = "℃";
            label7.Text = "℃";
            label8.Text = "℃";
            label9.Text = "℃";
            label10.Text = "℃";
            label11.Text = "℃";
            label12.Text = "℃";
            label13.Text = "℃";
        }

        private void strtext()
        {
            string str = textBox1.Text;
            string check1 = "비";
            string check2 = "눈";
            string check3 = "황사";
            string check4 = "미세먼지";
            string check5 = "강풍";

            Console.WriteLine(textBox1.Text);

            if (str.Contains(check1))
            {
                Console.WriteLine("비 있음");
                label14.Text = "비가 내리니 우산을 챙기세요!";
            }
            else if (str.Contains(check2))
            {
                Console.WriteLine("눈 있음");
                label14.Text = "눈이 내리니 빙판길 조심하세요!";
            }
            else if (str.Contains(check3))
            {
                Console.WriteLine("황사 있음");
                label14.Text = "황사가 심하니 마스크를 챙기세요!";
            }
            else if (str.Contains(check4))
            {
                Console.WriteLine("미세먼지 있음");
                label14.Text = "미세먼지가 심하니 마스크를 챙기세요!";
            }
            else if (str.Contains(check5))
            {
                Console.WriteLine("강풍 있음");
                label14.Text = "바람이 심하게 부니 따뜻하게 입고 나가세요!";
            }
            else
            {                
                Console.WriteLine("없음");
                label14.Text = "";
            }
        }

        private void comboBox_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox_city.Text);
                        
            resetpic();

            try
            {
                using (XmlReader xr = XmlReader.Create(url))
                {
                    string msg = "";
                    XmlWriterSettings ws = new XmlWriterSettings();
                    ws.Indent = true;
                    bool check = false;
                    int count = 0;
                    city = comboBox_city.Text;

                    while (xr.Read())
                    {
                        switch (xr.NodeType)
                        {
                            case XmlNodeType.CDATA:
                                {
                                    textBox1.Text = xr.Value.ToString().Replace("<br />", "");
                                    break;
                                }
                            /*case XmlNodeType.None:                                
                                break;*/
                            case XmlNodeType.Element:
                                break;
                            /*case XmlNodeType.Attribute:
                                break;*/
                            case XmlNodeType.Text:
                                {
                                    if (xr.Value.Equals(city))
                                    {
                                        check = true;
                                    }
                                    if (check)
                                    {
                                        DateTime ti;
                                        bool b = DateTime.TryParse(xr.Value.ToString(), out ti);
                                        if (b)
                                        {
                                            msg += "/";
                                        }
                                        msg += xr.Value + ",";
                                        count += 1;
                                        if (count > 36)
                                        {
                                            check = false;
                                        }
                                    }
                                    break;
                                }                                                                   
                            /*case XmlNodeType.EntityReference:
                                break;*/
                            /*case XmlNodeType.Entity:
                                break;*/
                            case XmlNodeType.ProcessingInstruction:
                                break;
                            case XmlNodeType.Comment:
                                break;
                            /*case XmlNodeType.Document:
                                break;*/
                            /*case XmlNodeType.DocumentType:
                                break;*/
                            /*case XmlNodeType.DocumentFragment:
                                break;*/
                            /*case XmlNodeType.Notation:
                                break;*/
                            /*case XmlNodeType.Whitespace:
                                break;*/
                           /* case XmlNodeType.SignificantWhitespace:
                                break;*/
                            case XmlNodeType.EndElement:
                                break;
                            case XmlNodeType.EndEntity:
                                break;
                            case XmlNodeType.XmlDeclaration:
                                break;
                            default:
                                break;
                        }
                    }
                    // 요일별
                    string[] strtemp = msg.Split('/');

                    //요일별 데이터
                    string[] strtemp1 = strtemp[1].Split(',');
                    label_day1.Text = strtemp1[0];
                    label_low_text1.Text = strtemp1[2];
                    label_high_text1.Text = strtemp1[3];
                    label_weather_text1.Text = "요약 : " + strtemp1[1];                
                    avg = (int.Parse(strtemp1[2]) + int.Parse(strtemp1[3])) / 2;
                    Console.WriteLine($"{label_day1.Text} 평균 기온 : " + avg);
                    //label_avg.Text = avg.ToString();

                    string[] strtemp2 = strtemp[2].Split(',');
                    label_day2.Text = strtemp2[0];
                    label_low_text2.Text = strtemp2[2];
                    label_high_text2.Text = strtemp2[3];
                    label_weather_text2.Text = "요약 : " + strtemp2[1];
                    avg = (int.Parse(strtemp2[2]) + int.Parse(strtemp2[3])) / 2;
                    Console.WriteLine($"{label_day2.Text} 평균 기온 : " + avg);
                    //label_avg.Text = avg.ToString();

                    string[] strtemp3 = strtemp[3].Split(',');
                    label_day3.Text = strtemp3[0];
                    label_low_text3.Text = strtemp3[2];
                    label_high_text3.Text = strtemp3[3];
                    label_weather_text3.Text = "요약 : " + strtemp3[1];
                    avg = (int.Parse(strtemp3[2]) + int.Parse(strtemp3[3])) / 2;
                    Console.WriteLine($"{label_day3.Text} 평균 기온 : " + avg);
                    //label_avg.Text = avg.ToString();

                    string[] strtemp4 = strtemp[4].Split(',');
                    label_day4.Text = strtemp4[0];
                    label_low_text4.Text = strtemp4[2];
                    label_high_text4.Text = strtemp4[3];
                    label_weather_text4.Text = "요약 : " + strtemp4[1];
                    avg = (int.Parse(strtemp4[2]) + int.Parse(strtemp4[3])) / 2;
                    Console.WriteLine($"{label_day4.Text} 평균 기온 : " + avg);
                    //label_avg.Text = avg.ToString();

                    string[] strtemp5 = strtemp[5].Split(',');
                    label_day5.Text = strtemp5[0];
                    label_low_text5.Text = strtemp5[2];
                    label_high_text5.Text = strtemp5[3];
                    label_weather_text5.Text = "요약 : " + strtemp5[1];
                    avg = (int.Parse(strtemp5[2]) + int.Parse(strtemp5[3])) / 2;
                    Console.WriteLine($"{label_day5.Text} 평균 기온 : " + avg);
                    //label_avg.Text = avg.ToString();

                    string[] strtemp6 = strtemp[6].Split(',');
                    label_day6.Text = strtemp6[0];
                    label_low_text6.Text = strtemp6[2];
                    label_high_text6.Text = strtemp6[3];
                    label_weather_text6.Text = "요약 : " + strtemp6[1];
                    avg = (int.Parse(strtemp6[2]) + int.Parse(strtemp6[3])) / 2;
                    Console.WriteLine($"{label_day6.Text} 평균 기온 : " + avg);
                    //label_avg.Text = avg.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);               
                //throw;
            }
        }     

        private void calc1()
        {
            label_avg.Text = "";
            double result1 = (int.Parse(label_high_text1.Text) + int.Parse(label_low_text1.Text)) / 2;
            label_avg.Text = result1.ToString();
        }

        private void calc2()
        {
            label_avg.Text = "";
            double result2 = (int.Parse(label_high_text2.Text) + int.Parse(label_low_text2.Text)) / 2;
            label_avg.Text = result2.ToString();
        }

        private void calc3()
        {
            label_avg.Text = "";
            double result3 = (int.Parse(label_high_text3.Text) + int.Parse(label_low_text3.Text)) / 2;
            label_avg.Text = result3.ToString();
        }

        private void calc4()
        {
            label_avg.Text = "";
            double result4 = (int.Parse(label_high_text4.Text) + int.Parse(label_low_text4.Text)) / 2;
            label_avg.Text = result4.ToString();
        }

        private void calc5()
        {
            label_avg.Text = "";
            double result5 = (int.Parse(label_high_text5.Text) + int.Parse(label_low_text5.Text)) / 2;
            label_avg.Text = result5.ToString();
        }

        private void calc6()
        {
            label_avg.Text = "";
            double result6 = (int.Parse(label_high_text6.Text) + int.Parse(label_low_text6.Text)) / 2;
            label_avg.Text = result6.ToString();
        }

        private void command()
        {
            if (int.Parse(label_avg.Text) <= 5)
            {
                Console.WriteLine($"추천 옷차림 : 패딩, 두꺼운 코트, 목도리, 기모제품");
                label_avg.Text = $"평균 기온 : {label_avg.Text}";
                label_comm.Text = $"추천 옷차림 : 패딩, 두꺼운 코트, 목도리, 기모제품";
                pictureBox1.Image = Webimage("https://image.msscdn.net/images/codimap/detail/402/detail_402_1_500.jpg?202105131105");
            }
            else if (6 <= int.Parse(label_avg.Text) && int.Parse(label_avg.Text) <= 9)
            {
                Console.WriteLine($"추천 옷차림 : 코트, 가죽자켓, 니트, 레깅스");
                label_avg.Text = $"평균 기온 : {label_avg.Text}";
                label_comm.Text = $"추천 옷차림 : 코트, 가죽자켓, 니트, 레깅스";
                pictureBox1.Image = Webimage("https://image.msscdn.net/images/codimap/detail/421/detail_421_1_500.jpg?202105131105");
            }
            else if (10 <= int.Parse(label_avg.Text) && int.Parse(label_avg.Text) <= 11)
            {
                Console.WriteLine($"추천 옷차림 : 자켓, 트렌치코트, 야상, 니트, 청바지, 스타킹");
                label_avg.Text = $"평균 기온 : {label_avg.Text}";
                label_comm.Text = $"추천 옷차림 : 자켓, 트렌치코트, 야상, 니트, 청바지, 스타킹";
                pictureBox1.Image = Webimage("https://image.msscdn.net/images/codimap/detail/569/detail_569_1_500.jpg?202105131105");
            }
            else if (12 <= int.Parse(label_avg.Text) && int.Parse(label_avg.Text) <= 16)
            {
                Console.WriteLine($"추천 옷차림 : 가디건, 자켓, 야상, 스타킹, 청바지, 면바지");
                label_avg.Text = $"평균 기온 : {label_avg.Text}";
                label_comm.Text = $"추천 옷차림 : 가디건, 자켓, 야상, 스타킹, 청바지, 면바지";
                pictureBox1.Image = Webimage("https://image.msscdn.net/images/codimap/detail/2161/detail_2161_1_500.jpg?202105131105");
            }
            else if (17 <= int.Parse(label_avg.Text) && int.Parse(label_avg.Text) <= 19)
            {
                Console.WriteLine($"추천 옷차림 : 맨투맨, 얇은 니트, 가디건, 청바지");
                label_avg.Text = $"평균 기온 : {label_avg.Text}";
                label_comm.Text = $"추천 옷차림 : 맨투맨, 얇은 니트, 가디건, 청바지";
                pictureBox1.Image = Webimage("https://image.msscdn.net/images/codimap/detail/232/detail_232_1_500.jpg?202105131105");
            }
            else if (20 <= int.Parse(label_avg.Text) && int.Parse(label_avg.Text) <= 22)
            {
                Console.WriteLine($"추천 옷차림 : 긴팔, 얇은 가디건, 면바지, 청바지");
                label_avg.Text = $"평균 기온 : {label_avg.Text}";
                label_comm.Text = $"추천 옷차림 : 긴팔, 얇은 가디건, 면바지, 청바지";
                pictureBox1.Image = Webimage("https://image.msscdn.net/images/codimap/detail/2546/detail_2546_1_500.jpg?202105131105");
            }
            else if (23 <= int.Parse(label_avg.Text) && int.Parse(label_avg.Text) <= 26)
            {
                Console.WriteLine($"추천 옷차림 : 얇은 셔츠, 반팔, 반바지, 면바지");
                label_avg.Text = $"평균 기온 : {label_avg.Text}";
                label_comm.Text = $"추천 옷차림 : 얇은 셔츠, 반팔, 반바지, 면바지";
                pictureBox1.Image = Webimage("https://image.msscdn.net/images/codimap/detail/2688/detail_2688_1_500.jpg?202105131105");
            }
            else if (27 <= int.Parse(label_avg.Text))
            {
                Console.WriteLine($"추천 옷차림 : 반팔, 민소매, 반바지, 원피스");
                label_avg.Text = $"평균 기온 : {label_avg.Text}";
                label_comm.Text = $"추천 옷차림 : 반팔, 민소매, 반바지, 원피스";
                pictureBox1.Image = Webimage("https://image.msscdn.net/images/codimap/detail/3008/detail_3008_1_500.jpg?202105131105");
            }
        }

        private Bitmap Webimage(string link)
        {
            try
            {
                WebClient Downloader = new WebClient();
                Stream ImageStream = Downloader.OpenRead(link);
                Bitmap DownloadImage = Bitmap.FromStream(ImageStream) as Bitmap;
                return DownloadImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                return null;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            calc1();
            command();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            calc2();
            command();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            calc3();
            command();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            calc4();
            command();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            calc5();
            command();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            calc6();
            command();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text1.BackColor = Color.FromArgb(110, 163, 168);
            label_day1.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text1.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text1.BackColor = Color.FromArgb(110, 163, 168);
            label1.BackColor = Color.FromArgb(110, 163, 168);
            label2.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            label_day1.BackColor = Color.White;
            label_high_text1.BackColor = Color.White;
            label_low_text1.BackColor = Color.White;
            label_weather_text1.BackColor = Color.White;
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text1.BackColor = Color.FromArgb(110, 163, 168);
            label_day1.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text1.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text1.BackColor = Color.FromArgb(110, 163, 168);
            label1.BackColor = Color.FromArgb(110, 163, 168);
            label2.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {

            panel2.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text2.BackColor = Color.FromArgb(110, 163, 168);
            label_day2.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text2.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text2.BackColor = Color.FromArgb(110, 163, 168);
            label3.BackColor = Color.FromArgb(110, 163, 168);
            label4.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
            label_day2.BackColor = Color.White;
            label_high_text2.BackColor = Color.White;
            label_low_text2.BackColor = Color.White;
            label_weather_text2.BackColor = Color.White;
            label3.BackColor = Color.White;
            label4.BackColor = Color.White;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text2.BackColor = Color.FromArgb(110, 163, 168);
            label_day2.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text2.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text2.BackColor = Color.FromArgb(110, 163, 168);
            label3.BackColor = Color.FromArgb(110, 163, 168);
            label4.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text3.BackColor = Color.FromArgb(110, 163, 168);
            label_day3.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text3.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text3.BackColor = Color.FromArgb(110, 163, 168);
            label5.BackColor = Color.FromArgb(110, 163, 168);
            label6.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.White;
            label_day3.BackColor = Color.White;
            label_high_text3.BackColor = Color.White;
            label_low_text3.BackColor = Color.White;
            label_weather_text3.BackColor = Color.White;
            label5.BackColor = Color.White;
            label6.BackColor = Color.White;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text3.BackColor = Color.FromArgb(110, 163, 168);
            label_day3.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text3.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text3.BackColor = Color.FromArgb(110, 163, 168);
            label5.BackColor = Color.FromArgb(110, 163, 168);
            label6.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text4.BackColor = Color.FromArgb(110, 163, 168);
            label_day4.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text4.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text4.BackColor = Color.FromArgb(110, 163, 168);
            label7.BackColor = Color.FromArgb(110, 163, 168);
            label8.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.White;
            label_day4.BackColor = Color.White;
            label_high_text4.BackColor = Color.White;
            label_low_text4.BackColor = Color.White;
            label_weather_text4.BackColor = Color.White;
            label7.BackColor = Color.White;
            label8.BackColor = Color.White;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            panel4.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text4.BackColor = Color.FromArgb(110, 163, 168);
            label_day4.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text4.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text4.BackColor = Color.FromArgb(110, 163, 168);
            label7.BackColor = Color.FromArgb(110, 163, 168);
            label8.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text5.BackColor = Color.FromArgb(110, 163, 168);
            label_day5.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text5.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text5.BackColor = Color.FromArgb(110, 163, 168);
            label9.BackColor = Color.FromArgb(110, 163, 168);
            label10.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.White;
            label_day5.BackColor = Color.White;
            label_high_text5.BackColor = Color.White;
            label_low_text5.BackColor = Color.White;
            label_weather_text5.BackColor = Color.White;
            label9.BackColor = Color.White;
            label10.BackColor = Color.White;
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            panel5.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text5.BackColor = Color.FromArgb(110, 163, 168);
            label_day5.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text5.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text5.BackColor = Color.FromArgb(110, 163, 168);
            label9.BackColor = Color.FromArgb(110, 163, 168);
            label10.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text6.BackColor = Color.FromArgb(110, 163, 168);
            label_day6.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text6.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text6.BackColor = Color.FromArgb(110, 163, 168);
            label11.BackColor = Color.FromArgb(110, 163, 168);
            label12.BackColor = Color.FromArgb(110, 163, 168);
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.White;
            label_day6.BackColor = Color.White;
            label_high_text6.BackColor = Color.White;
            label_low_text6.BackColor = Color.White;
            label_weather_text6.BackColor = Color.White;
            label11.BackColor = Color.White;
            label12.BackColor = Color.White;
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            panel6.BackColor = Color.FromArgb(110, 163, 168);
            label_high_text6.BackColor = Color.FromArgb(110, 163, 168);
            label_day6.BackColor = Color.FromArgb(110, 163, 168);
            label_low_text6.BackColor = Color.FromArgb(110, 163, 168);
            label_weather_text6.BackColor = Color.FromArgb(110, 163, 168);
            label11.BackColor = Color.FromArgb(110, 163, 168);
            label12.BackColor = Color.FromArgb(110, 163, 168);
        }
    }
}
