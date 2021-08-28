using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using System.Text.RegularExpressions;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private enum eUserChoice
        {
            AddNewVehicleToTheGarage,
            DisplayAllVehiclesInTheGarage,
            ChangeVehicleStatus,
            InflateVehicleTires,
            RefuelVehicle,
            ChargeVehicle,
            DisplayVehicleData,
            Exit
        }

        private readonly GarageManager r_GarageManager;
        private eUserChoice m_UserChoice;
        private bool m_ExitFromSystem = false;

        public UI()
        {
            r_GarageManager = new GarageManager();
            m_ExitFromSystem = false;
        }

        public void Run()
        {
            while(!m_ExitFromSystem)
            {
                try
                {
                    displayMenu();
                    getUserEnumChoice(out m_UserChoice);
                    Console.Clear();
                    switch(m_UserChoice)
                    {
                        case eUserChoice.AddNewVehicleToTheGarage:
                            addNewVehicleToTheGarage();
                            break;

                        case eUserChoice.DisplayAllVehiclesInTheGarage:
                            displayAllVehiclesInTheGarage();
                            break;

                        case eUserChoice.ChangeVehicleStatus:
                            changeVehicleStatus();
                            break;

                        case eUserChoice.InflateVehicleTires:
                            inflateVehicleTires();
                            break;

                        case eUserChoice.RefuelVehicle:
                            refuelVehicle();
                            break;

                        case eUserChoice.ChargeVehicle:
                            chargeVehicle();
                            break;

                        case eUserChoice.DisplayVehicleData:
                            displayVehicleData();
                            break;

                        case eUserChoice.Exit:
                            m_ExitFromSystem = true;
                            break;

                        default:
                            break;
                    }
                }
                catch(ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"The maximum valid input is: {e.MaxValue}");
                    Console.WriteLine($"The minimum valid input is: {e.MinValue}");
                    PressAnyKeyToContinue();
                }
                catch(AggregateException e)
                {
                    Console.WriteLine($"This is not valid operation: {e.Message}");
                    PressAnyKeyToContinue();
                }
                catch(FormatException e)
                {
                    Console.WriteLine($"This is has an incorrect format: {e.Message}");
                    PressAnyKeyToContinue();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    PressAnyKeyToContinue();
                }
            }
        }

        private static void displayMenu()
        {
            Console.Clear();
            showEnumOptions<eUserChoice>();
        }

        private static void showEnumOptions<TEnum>()
        {
            StringBuilder stringToPrint = new StringBuilder();
            stringToPrint.Append("Please choose one option from the list below:");
            foreach(string option in Enum.GetNames(typeof(TEnum)))
            {
                stringToPrint.Append(Environment.NewLine);
                stringToPrint.Append($"{Enum.Parse(typeof(TEnum), option):D}. {camelcaseToSentenceCase(option)}");
            }

            Console.WriteLine(stringToPrint);
        }

        private static string camelcaseToSentenceCase(string i_StrToReformat)
        {
            if(char.IsLower(i_StrToReformat[0]))
            {
                i_StrToReformat = $"{char.ToUpper(i_StrToReformat[0]) + i_StrToReformat.Substring(1)}";
            }

            string output = Regex.Replace(i_StrToReformat, @"\p{Lu}", m => " " + m.Value.ToLowerInvariant());
            output = char.ToUpperInvariant(output[0]) + output.Substring(1);
            return output;
        }

        private void getUserEnumChoice<TEnum>(out TEnum i_UserChice) where TEnum : struct
        {
            int numOfOptions = Enum.GetNames(typeof(TEnum)).Length;
            string userInputStr = Console.ReadLine();
            if(!(Enum.TryParse<TEnum>(userInputStr, out i_UserChice) && Enum.IsDefined(typeof(TEnum), i_UserChice)))
            {
                throw new FormatException();
            }
        }

        private void addNewVehicleToTheGarage()
        {
            
        }
    }
}
