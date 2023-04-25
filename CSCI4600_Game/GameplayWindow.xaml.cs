using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSCI4600_Game
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class GameplayWindow : Window
    {
        internal GameplayWindow(SaveGameState currentSave)
        {

            InitializeComponent();
            {
                //Resets position counter when window1 opened
                postionCounter=0;
            }
        }

        /******************************************************************

        User Class

        CurrentCharacter Class

        MetaShop Class

        Wiki Class





       /********************************************************************


        NOTE:
        When attaching item or character images use in C file follow format:

        Uri mapImage1 = new Uri("\\Resources\\mapImage_1.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage1);

        ******************************************************************/










        //Begin Game Mechanics
        /***********************************************************************************/

        public static int postionCounter = 0;
        public bool gameState = true;
       


        private void Yes_Click(object sender, RoutedEventArgs e) {
         //choiceYes(position)
             int position = postionCounter;
            if (position == 0)
            {
                position = 1;
                postionCounter = 1;
                GamePlay(position);
            }

            else if (position== 1)
            {
                position = 2;
                postionCounter = 2;
                GamePlay(position);
            }
           else if (position == 2)
            {
                position = 12;
                postionCounter = 12;
                GamePlay(position);
            }
            else if (position == 3)
            {
                position = 6;
                postionCounter = 6;
                GamePlay(position);
            }
           else if (position == 4)
            {
                position = 9;
                postionCounter = 9;
                GamePlay(position);
            }
           else if (position == 5)
            {
                position = 8;
                postionCounter = 8;
                GamePlay(position);
            }
           else if (position == 6)
            {
                position = 4;
                postionCounter = 4;
                GamePlay(position);
            }
           else if (position == 7)
            {
                position = 2;
                postionCounter = 2;
                GamePlay(position);
            }
           else if (position == 8)
            {
                position = 10;
                postionCounter = 10;
                GamePlay(position);
            }
           else if (position == 9)
            {
                position = 4;
                postionCounter = 4;
                GamePlay(position);
            }
           else if (position == 10)
            {
                position = 13;
                postionCounter = 13;
                GamePlay(position);
            }
            else 
                  { 
                position = -1;
                  GamePlay(position);
                }
        }
        private void No_Click(object sender, RoutedEventArgs e)
        {

            //Create option class/call function?
            //choiceNo(position)
            int position = postionCounter;
            if (position == 0)
            {
                position = -1;
                postionCounter = -1;
                GamePlay(position);
            }
            else if (position == 1)
            {
                position = 3;
                postionCounter = 3;
                GamePlay(position);
            }
           else if (position == 2)
            {
                position = 5;
                postionCounter = 5;
                GamePlay(position);
            }
           else if (position == 3)
            {
                position =7;
                postionCounter = 7;
                GamePlay(position);
            }
           else if (position == 4)
            {
                position = 9;
                postionCounter = 9;
                GamePlay(position);
            }
            else if (position == 5)
            {
                position = 11;
                postionCounter = 11;
                GamePlay(position);
            }
            else if (position == 6)
            {
                position = 4;
                postionCounter = 4;
                GamePlay(position);
            }
            else if (position == 7)
            {
                position = 15;
                postionCounter = 15;
                GamePlay(position);
            }
           else if (position == 8)
            {
                position = 16;
                postionCounter = 16;
                GamePlay(position);
            }
            else if (position == 9)
            {
                position = -1;
                postionCounter = -1;
                GamePlay(position);
            }
            else if (position == 10)
            {
                position = 14;
                postionCounter = 14;
                GamePlay(position);
            }
          
            else
            {
                postionCounter = -1;
                GamePlay(position);
            }
        }


        //Begin GamePlay() 
        //Put in class/function call?
        /**********************************************************************/
        public void  GamePlay(int positionCounter)
            {

                switch (positionCounter)
                {

                    case 1:
                        {
                        Uri mapImage1 = new Uri("\\Resources\\mapImage_1.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage1);
                        Story_TextBlock.Text = "You find yourself in a fantastical land! You come across a group of weary travelers who are on a quest for redemption. They are searching for a magic piece of bubble gum that has the power to restore the honor of their fallen kingdom. Do you join their quest?";
                        
                        //Including more attribute adjustments in each CASE as needed


                        break;
                        }
                    case 2:
                    {
                        Uri mapImage2 = new Uri("\\Resources\\mapImage_2.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage2); 
                        Story_TextBlock.Text = "You join the group of travelers on their quest. After giving you some coin for your troubles and heading upon your merry way, you encounter a diabolical looking turtle! He stands in your path and will NOT MOVE! \r\nDo you poke the turtle?";
                        
                        break;
                    }
                    case 3:
                    {
                        Uri mapImage3 = new Uri("\\Resources\\mapImage_3.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage3); 
                        Story_TextBlock.Text = "You decide they aren't worth the trouble and continue on your own. You stumble upon curious looking music box that has been abandoned by its owner. It smells badly and appears to be sticky. Do you wind the crank?";
                       
                        break;
                    }
                case 4:
                    {
                        Uri mapImage4 = new Uri("\\Resources\\mapImage_4.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage4); 
                        Story_TextBlock.Text = "As you open your mouth to speak, he laughs, and envelopes you in a pruple light...you start to cough and choke... do you run?";
                        break;
                    }
                case 5:
                    {
                        Uri mapImage5 = new Uri("\\Resources\\mapImage_5.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage5); 
                        Story_TextBlock.Text = "You decide NOT to poke the turtle (because you are a decent chap). The turtle recedes into his shell (as turtles do) and you have no further trouble out of him. The group of travelers are impressed by your skills. Do you accept their HIGH FIVES?";
                        break;
                    }
                case 6:
                    {
                        Uri mapImage6 = new Uri("\\Resources\\mapImage_6.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage6); 
                        Story_TextBlock.Text = "You crank that dirty box for all its worth...after a few out of tune notes a genie POPS out of the top! Offering one wish.. he awaits your answer. Will you accept?";
                        break;
                    }
                case 7:
                    {
                        Uri mapImage7 = new Uri("\\Resources\\mapImage_7.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage7); 
                        Story_TextBlock.Text = "You step over the tiny music box and continue down the path. Ahead you see those same weary travelers again. Do you decide to change your mind and join them?";
                        break;
                    }
                case 8:
                    {
                        Uri mapImage8 = new Uri("\\Resources\\mapImage_8.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage8);
                        Story_TextBlock.Text = "\"Slay!\" ...you say accepting the high fives like a boss. You and the group of travelers continue down the path until you come upon a rather shabby looking Teddy Bear who challenges you to a game of riddles to win.. what else?!!? A magical peice of bubble gum! Do you accept the challenge?";
                        break;
                    }
                case 9:
                    {
                        Uri mapImage9 = new Uri("\\Resources\\mapImage_9.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage9); 
                        Story_TextBlock.Text = "You find that no matter how hard you try you cannot escape...you slowing crumple to the ground and before you know it you are fast asleep... perhaps when you wake up you can find a better path";
                        break;
                    }
                case 10:
                    {
                        Uri mapImage10 = new Uri("\\Resources\\mapImage_10.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage10); 
                        Story_TextBlock.Text = "You accept the teddy bear's challenge and successfully solve all the riddles.(Which consisted bad puns and knock knock jokes) The Teddy bear hands over the magic piece of bubble gum and wishes you luck on your quest. Do you give your traveling companions the magical bubble gum?";
                        break;
                    }
                case 11:
                    {
                        Uri mapImage11 = new Uri("\\Resources\\mapImage_11.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage11); 
                        Story_TextBlock.Text = "You shrug off the enthusiasm of the group. They huddle and take a vote removing you from the party. ...something about not needing that type of negativity in their lives. They invite you to try again another day when you can show a bit more enthusiasm!";
                        break;
                    }
                case 12:
                    {
                        Uri mapImage12 = new Uri("\\Resources\\mapImage_12.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage12); Story_TextBlock.Text = "You engage in a fierce battle with the evil turtle but it proves to be too strong for you. You are defeated and the group of travelers continue on their quest without you. (..because who attacks a turtle anyway! Perhaps you will see them again one day...";
                        break;
                    }
                case 13:
                    {
                        Uri mapImage13 = new Uri("\\Resources\\mapImage_13.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage13); 
                        Story_TextBlock.Text = "You successfully obtain the magic piece of bubble gum and give it to the group of travelers. They use the gum to restore the honor of their fallen kingdom and thank you for your help. You continue on your own journey, knowing that you have made a real difference in this land of ADVENTURE!";
                        break;
                    }
                case 14:
                    {
                        Uri mapImage14 = new Uri("\\Resources\\mapImage_14.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage14); 
                        Story_TextBlock.Text = "You suddenly become mad with desire for the power promised by the magical piece of bubble gum! A maniacal laugh emminates from your nethers and echoes across the valley. In one swift motion you unwrap the treasure and pop it into your mouth. Instantly you feel.... nothing... it didnt work and you are now left alone by the roadside. Perhaps there are better choices you could have made along the way..";
                        break;
                    }
                case 15:
                    {
                        Uri mapImage16 = new Uri("\\Resources\\mapImage_16.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage16); Story_TextBlock.Text = "After skipping past tra-la-la-ing you feel very happy with yourself...until you trip on your shoelace and faceplant in front of them all... as you sit nursing your ego you resign yourself to a nap and perhaps trying this adventure again one day in the future.";
                        break;
                    }
                case 16:
                    {
                        Uri mapImage15 = new Uri("\\Resources\\mapImage_15.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage15); 
                        Story_TextBlock.Text = "As you turn to walk away the Teddy Bear eats you. The end";
                        break;
                    }
                    case -1:
                    {
                        Uri mapImage16 = new Uri("\\Resources\\mapImage_16.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage16);
                        Story_TextBlock.Text = "You have found the end of the road dude";
                        break;
                    }
                    default:
                    {
                        Uri mapImage16 = new Uri("\\Resources\\mapImage_16.png", UriKind.Relative);
                        mapImage.Source = new BitmapImage(mapImage16);
                        Story_TextBlock.Text = "You have found the end of the road dude";
                        break;
                    }

            }
           





        }

   
        



    }
}
