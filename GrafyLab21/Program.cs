using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrafyLab21 {
    class Program {

        static List<Node> mojParser(string fileName) {

            string[] data2 = File.ReadAllLines(".\\" + fileName); //Pobierz plik
            Array.Resize(ref data2, data2.Length - 1); //Usuń ostatni wiersz, jest to tylko '}'
            data2 = data2.Skip(1).ToArray(); //Usuń pierwszy wiersz
            for (int i1 = 0; i1 < data2.Length; i1++) { //Usuń każdy średnik
                data2[i1] = data2[i1].Remove(data2[i1].Length - 1);
            }

            List<Node> test = new List<Node>();

            foreach (string line in data2) {
                if (!line.Contains(' ')) test.Add(new Node (int.Parse(line),new List<int>(new int[] { }) )); //Jeżeli nie ma w wierzu spacji to znaczy że jest to id wierzchołka, stwórz nowy wierzchołek i nadaj mu to id
                else { //Jeżeli ma spacje jest to połączenie, dodaj do jednego i drugiego id połączenie
                    char[] charArr = line.ToCharArray();
                    string number1 = "";
                    string number2 = "";
                    bool foundSpace = false;

                    for (int j = 0; j < charArr.Length; j++) {

                        if (charArr[j] == ' ') {
                            foundSpace = true;
                            j += 4;
                        }
                        if (!foundSpace) number1 += charArr[j];
                        else number2 += charArr[j];
                    }

                    test[int.Parse(number2)].canGetToFrom.Add(int.Parse(number1));

                }
            }

            return test;
        }
        static bool templateName(List<int> visited, int id, List<Node> nodes, List<int> results) {
            bool goldenCity = false;
            if (results.Contains(id)) {
                goldenCity = true;
                
            }
            else {
                visited.Add(id);

                for (int i = 0; i < nodes[id].canGetToFrom.Count; i++) {
                    if (!visited.Contains(nodes[id].canGetToFrom[i])) goldenCity = templateName(visited, nodes[id].canGetToFrom[i], nodes, results);
                    if (goldenCity) i = nodes[id].canGetToFrom.Count;
                }
                
            }
            return goldenCity;
        }

        static void Main(string[] args) {

             
            if (args.Count() == 1 && File.Exists(".\\" + args[0])) { 
                List<Node> nodes = mojParser(args[0]);

                /*Testowe zadanie z cwiczenia
                List<Node> nodes2 = new List<Node>();
                nodes2.Add(new Node(0, new List<int> { }));
                nodes2.Add(new Node(1, new List<int> {0,2 }));
                nodes2.Add(new Node(2, new List<int> {0,4,3 }));
                nodes2.Add(new Node(3, new List<int> {5 }));
                nodes2.Add(new Node(4, new List<int> {1 }));
                nodes2.Add(new Node(5, new List<int> {3 }));
                koniec testowego*/
                List<int> result = new List<int>();

                for(int i = 0; i < nodes.Count; i++) {
                    List<int> visited = new List<int>();
                    bool goldenCity = false; //Jeżeli jesteśmy w mieście które jest już na liście rezultatów (można do niego trafić z wszystkich innych miast) to znaczy że można też trafić do tego początkowego miasta z wszystkich
                    goldenCity = templateName(visited, i, nodes, result);  //Do których można dojechać z niego
                    if (visited.Count == nodes.Count || goldenCity == true) result.Add(i);
                }

                Console.WriteLine("Wierzchołkami spełniajacymi warunek są:");

                for (int i = 0; i < result.Count; i++) Console.Write(result[i] + ", ");
                
            }
            else Console.WriteLine("Podaj poprawną nazwe pliku!");

            Console.ReadLine();
        }
    }
}
