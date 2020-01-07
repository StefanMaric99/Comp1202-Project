using System;

using System.IO;

namespace Project
{
    class GroupProject
    {
        static void Main()
        {

            
            {
                //starts the stopwatch to determine how long it took to run the program
                

                int if_zero;
                string[] correct_answers = new string[1];
                string exam_text;
                int[] exam_id = new int[200];
                string[] exam_answers = new string[200];
                string[] exam_string;

                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\test.txt");

                //Read the first line of text and marks it as the correct answer
                correct_answers[0] = sr.ReadLine();

                //Sets the counter to the correct answer length
                int[] counter = new int[correct_answers[0].Length];

                //Takes all other lines and puts them into exam_texts
                exam_text = sr.ReadLine();

                //Takes all exam_texts lines and puts them into test while being split up
                exam_string = exam_text.Split();
                if_zero = Convert.ToInt32(exam_string[0]);

                //Continue to read until you reach end of file
                for (int x = 0; if_zero != 0; x++)
                {
                    //Takes test 1 and puts it into student_answer of i
                    exam_answers[x] = exam_string[1];

                    //Takes test 0 and puts it into student_i of i
                    exam_id[x] = Convert.ToInt32(exam_string[0]);

                    //Read the next line until it finds zero
                    exam_text = sr.ReadLine();
                    exam_string = exam_text.Split();
                    if_zero = Convert.ToInt32(exam_string[0]);
                }
                //close the file
                sr.Close();

                int id_count = 0;
                for (int i = 0; i < exam_id.Length; i++)
                {
                    if (exam_id[i] == 0)
                    {
                        break;
                    }
                    else
                    {
                        id_count++;
                    }
                }
                int[] student_id = new int[id_count];
                int[] student_marks = new int[id_count];
                string[] student_answers = new string[id_count];

                for (int i = 0; i < id_count; i++)
                {
                    student_id[i] = exam_id[i];
                }

                for (int i = 0; i < id_count; i++)
                {
                    student_answers[i] = exam_answers[i];
                }


                Calc(student_id, student_marks, student_answers, correct_answers, counter);
                Visual(student_id, student_marks, counter);

                
            
                
                Console.ReadKey();
            }
        }

        //Calculation of the Project
        static void Calc(int[] student_id, int[] student_marks, string[] student_answers, string[] correct_answers, int[] counter)
        {
            //loop to select elements in arrays one at a time
            for (int i = 0; i < (student_id.Length); i++)
            {
                //loop to select specific characters in the above elements one at a time
                for (int j = 0; j < 20; j++)
                {
                    //If the student has the same answer as the correct answer, they will get +4 in marks
                    if (correct_answers[0][j] == student_answers[i][j])
                    {
                        student_marks[i] += 4;
                        //To count how many students got the right answer
                        counter[j]++;
                    }
                    else
                    {
                        //If the student answered with X (did not answer), continues the code
                        if (student_answers[i][j] == 'X')
                        {
                            continue;
                        }
                        else
                        {
                            //If student didnt answer correctly or with an "X", they lose 1 mark
                            student_marks[i] -= 1;
                        }
                    }
                }
            }
        }


        //The visual aspect of the project  
        static void Visual(int[] student_id, int[] student_marks, int[] counter)
        {
            Console.WriteLine("************ MCQ STUDENT EXAM REPORT ************");
            Console.WriteLine("Student Number\t\t\t\tMark");
            //Displays the student id (in the array) and there marks (in the array)
            for (int i = 0; i < (student_id.Length); i++)
            {
                Console.WriteLine(student_id[i] + "\t\t\t\t\t" + student_marks[i]);
            }
            //Lenght - 1 because it also counts the "0" at the bottom of the document
            Console.WriteLine("\nThe total number of examination marked: " + student_id.Length);
            Console.WriteLine("Number of correct responses for each question:");
            Console.WriteLine("question: 1 \t2 \t3 \t4 \t5 \t6 \t7 \t8 \t9 \t10");
            Console.Write("#corect : ");
            //loop to display how many students answered correctly
            for (int i = 0; i < 10; i++)
            {
                Console.Write(counter[i] + "\t");
            }
            Console.WriteLine("\n\nquestion: 11\t12\t13\t14\t15\t16\t17\t18\t19\t20");
            Console.Write("#corect : ");
            //loop to display how many students answered correctly
            for (int i = 10; i < 20; i++)
            {
                Console.Write(counter[i] + "\t");
            }
        }
    }
}

