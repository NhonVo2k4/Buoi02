using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Buoi02
{
    class EdgeList
    {
        public LinkedList<int>[] A;
        LinkedList<Tuple<int, int>> g;
        int n;      // số đỉnh
        int m;      // số cạnh
        // Propeties
        public int N { get => n; set => n = value; }
        public int M { get => m; set => m = value; }
        public LinkedList<Tuple<int, int>> G { get => g; set => g = value; }
        // constructor
        public EdgeList()
        {
            g = new LinkedList<Tuple<int, int>>();
        }
        // Đọc file EdgeList.txt --> g
        public void FileToEdgeList(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string[] s = sr.ReadLine().Split();
            n = int.Parse(s[0]);
            m = int.Parse(s[1]);
            for (int i = 0; i < m; i++)
            {
                s = sr.ReadLine().Split();
                // khởi tạo một cạnh mới
                Tuple<int, int> e = new Tuple<int, int>(int.Parse(s[0]), int.Parse(s[1]));
                g.AddLast(e);
            }
            sr.Close();
        }
        // Xuat danh sach canh len man hinh
        public void Output()
        {
            Console.WriteLine("Danh sach canh cua do thi voi so dinh n = " + n );
            foreach (Tuple<int, int> e in g)
                Console.WriteLine("      (" + e.Item1 + "," + e.Item2 + ")");
        }

        public void EdgeListToFile(string fileOutput)
        {
            // Khởi tạo :
            using (StreamWriter sw = new StreamWriter(fileOutput)) 
            {
                sw.WriteLine(N);

                // Ghi vào file số đỉnh n

                // Duyệt từng đỉnh i, i = 0..n-1
                for (int i = 0; i < N; i++)
                {
                    // Gọi chuổi s :
                    string s = "";
                    // Duyệt các đỉnh liên kết trong v[i]


                    foreach (int x in A[i])
                        s = s + x + " ";
                    // Cắt khoảng trắng 2 đầu chuổi s

                    s=s.Trim();
                    // Ghi s vào file
                    sw.WriteLine(s);
                }
                sw.Close();
                
            }
           
        }
    }
}
