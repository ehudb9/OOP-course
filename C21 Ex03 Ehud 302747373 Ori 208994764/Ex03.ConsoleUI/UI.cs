using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
                    pressAnyKeyToContinue();
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine($"This is invalid operation: {e.Message}");
                    pressAnyKeyToContinue();
                }
                catch(FormatException e)
                {
                    Console.WriteLine($"This is has an incorrect format: {e.Message}");
                    pressAnyKeyToContinue();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    pressAnyKeyToContinue();
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
            output = char.ToUpperInvariant(output[1]) + output.Substring(2);
            return output;
        }

        private void getUserEnumChoice<TEnum>(out TEnum i_UserChoice) where TEnum : struct
        {
            int numOfOptions = Enum.GetNames(typeof(TEnum)).Length;
            string userInputStr = Console.ReadLine();
            if(!(Enum.TryParse<TEnum>(userInputStr, out i_UserChoice) && Enum.IsDefined(typeof(TEnum), i_UserChoice)))
            {
                throw new FormatException();
            }
        }

        private void addNewVehicleToTheGarage()
        {
            showEnumOptions<VehicleBuilder.eVehicleTypes>();
            getUserEnumChoice<VehicleBuilder.eVehicleTypes>(out VehicleBuilder.eVehicleTypes userChoice);
            Dictionary<string, VehicleBuilder.InsertDetails> vehicleNeededDataDictionary = VehicleBuilder.CreateNeededDataList(userChoice);
            Dictionary<string, object> vehicleDataDictionary = getVehicleDataFromUser(vehicleNeededDataDictionary);
            Vehicle newVehicle = VehicleBuilder.Create(userChoice, vehicleDataDictionary);
            Owner newVehicleOwner = getOwnerDataFromUser();
            r_GarageManager.InsertNewVehicle(newVehicle, newVehicleOwner);
        }

        private static Dictionary<string, object> getVehicleDataFromUser(Dictionary<string, VehicleBuilder.InsertDetails> i_VehicleNeededDataDictionary)
        {
            Dictionary<string, object> vehicleDataFromUserDictionary = new Dictionary<string, object>();
            string userInput;
            TypeConverter converter;
            object neededDataAsObject = null;

            foreach(KeyValuePair<string, VehicleBuilder.InsertDetails> data in i_VehicleNeededDataDictionary)
            {
                Console.WriteLine(data.Value.Question);
                if(data.Value.InputType.IsEnum)
                {
                    Console.WriteLine("Valid options: " + string.Join(", ", Enum.GetNames(data.Value.InputType)));
                }

                if(data.Value.InputType == typeof(bool))
                {
                    Console.WriteLine("Valid options: true, false");
                }

                userInput = Console.ReadLine();
                converter = TypeDescriptor.GetConverter(data.Value.InputType);
                if(converter.IsValid(userInput))
                {
                    neededDataAsObject = converter.ConvertFromString(userInput);
                }
                else
                {
                    throw new FormatException();
                }

                vehicleDataFromUserDictionary.Add(data.Key, neededDataAsObject);
            }

            return vehicleDataFromUserDictionary;
        }

        private static Owner getOwnerDataFromUser()
        {
            string ownerName;
            string ownerPhoneNumber;
            Owner newVehicleOwner;

            Console.WriteLine("Please type the name of the vehicle's owner:");
            ownerName = Console.ReadLine();
            Console.WriteLine("Please type the phone number of the vehicle's owner:");
            ownerPhoneNumber = Console.ReadLine();
            newVehicleOwner = new Owner(ownerName, ownerPhoneNumber);
            return newVehicleOwner;
        }

        private void displayAllVehiclesInTheGarage()
        {
            List<string> allVehiclesPlateNumber = new List<string>();
            bool validInput = false;
            string userInput;
            StringBuilder stringToPrint = new StringBuilder();
            int index = 1;

            Console.WriteLine("Do you want to filter the vehicles by their garage status?");
            Console.WriteLine("Valid Options: yes, no");

            while(!validInput)
            {
                userInput = Console.ReadLine();
                if(userInput == "yes")
                {
                    displayAllVehiclesInTheGarageFilter(allVehiclesPlateNumber);
                    validInput = true;
                }
                else if(userInput == "no")
                {
                    r_GarageManager.PresentVehiclesInTheGarageList(allVehiclesPlateNumber);
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("You typed invalid input, please try again");
                }
            }

            Console.WriteLine(allVehiclesPlateNumber.Count == 0 ? "There is no vehicles with that status in the garage" : "The vehicles in the garage are:");

            foreach(string plateNumber in allVehiclesPlateNumber)
            {
                stringToPrint.Append($"{index} - {plateNumber}");
                stringToPrint.Append(Environment.NewLine);
                index++;
            }

            Console.Clear();
            Console.WriteLine(stringToPrint.ToString());
            pressAnyKeyToContinue();
        }

        private void displayAllVehiclesInTheGarageFilter(List<string> i_AllVehiclesPlateNumber)
        {
            Console.WriteLine("Which of the following status do you want to filter by?");
            showEnumOptions<GarageManager.eGarageVehicleStatus>();
            getUserEnumChoice<GarageManager.eGarageVehicleStatus>(out GarageManager.eGarageVehicleStatus userChoice);
            r_GarageManager.PresentVehiclesInTheGarageListFiltered(i_AllVehiclesPlateNumber, userChoice);
        }

        private static string getVehiclePlateNumber()
        {
            string vehiclePlateNumber;
            Console.WriteLine("Please type the vehicle plate number");
            vehiclePlateNumber = Console.ReadLine();
            return vehiclePlateNumber;
        }

        private void changeVehicleStatus()
        {
            string vehiclePlateNumber = getVehiclePlateNumber();
            GarageManager.eGarageVehicleStatus vehicleStatus = r_GarageManager.GetVehicleStatus(vehiclePlateNumber);
            Console.WriteLine($"The current vehicle status is: {camelcaseToSentenceCase(vehicleStatus.ToString())}");
            Console.WriteLine("Enter the new vehicle status");
            showEnumOptions<GarageManager.eGarageVehicleStatus>();
            getUserEnumChoice(out GarageManager.eGarageVehicleStatus userNewStatusChoice);
            r_GarageManager.EditVehicleStatus(vehiclePlateNumber, userNewStatusChoice);
            Console.WriteLine("Vehicle status edit successfully");
            pressAnyKeyToContinue();
        }

        private void inflateVehicleTires()
        {
            string userInput;
            string vehiclePlateNumber = getVehiclePlateNumber();
            GarageManager.eGarageVehicleStatus vehicleStatus = r_GarageManager.GetVehicleStatus(vehiclePlateNumber);
            Console.WriteLine("Please type how much you want to inflate");
            userInput = Console.ReadLine();
            if(float.TryParse(userInput, out float amountToInflate))
            {
                r_GarageManager.InflateVehicleTires(vehiclePlateNumber, amountToInflate);
                Console.WriteLine($"All the tires have been inflated by {amountToInflate}");
                pressAnyKeyToContinue();
            }
            else
            {
                throw new FormatException();
            }
        }

        private void refuelVehicle()
        {
            string userInput;
            string vehiclePlateNumber = getVehiclePlateNumber();
            GarageManager.eGarageVehicleStatus vehicleStatus = r_GarageManager.GetVehicleStatus(vehiclePlateNumber);
            Console.WriteLine("Please choose your vehicle fuel type");
            showEnumOptions<FuelVehicle.eFuelType>();
            getUserEnumChoice<FuelVehicle.eFuelType>(out FuelVehicle.eFuelType vehicleFuelType);
            Console.WriteLine("Please type how much fuel you want to refuel");
            userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float amountToIRefuel))
            {
                r_GarageManager.RefuelVehicle(vehiclePlateNumber, vehicleFuelType, amountToIRefuel);
                Console.WriteLine($"Your vehicle refueled by {amountToIRefuel} liters");
                pressAnyKeyToContinue();
            }
            else
            {
                throw new FormatException();
            }
        }
        
        private void chargeVehicle()
        {
            string userInput;
            string vehiclePlateNumber = getVehiclePlateNumber();
            GarageManager.eGarageVehicleStatus vehicleStatus = r_GarageManager.GetVehicleStatus(vehiclePlateNumber);
            Console.WriteLine("Please type how many you want to inflate");
            userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float amountOfMinutesForCharge))
            {
                r_GarageManager.RechargeVehicle(vehiclePlateNumber, amountOfMinutesForCharge);
                Console.WriteLine($"Your vehicle charged by {amountOfMinutesForCharge} hours");
                pressAnyKeyToContinue();
            }
            else
            {
                throw new FormatException();
            }
        }

        private void displayVehicleData()
        {
            string vehiclePlateNumber = getVehiclePlateNumber();
            StringBuilder detailsToPrint = new StringBuilder();
            Dictionary<string, string> vehicleDataDictionary = r_GarageManager.ShowVehicleData(vehiclePlateNumber);
            foreach(KeyValuePair<string, string> detail in vehicleDataDictionary)
            {
                detailsToPrint.Append($"{camelcaseToSentenceCase(detail.Key)}: {detail.Value}");
                detailsToPrint.Append(Environment.NewLine);
            }

            Console.Clear();
            Console.WriteLine(detailsToPrint);
            pressAnyKeyToContinue();
        }

        private static void pressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
