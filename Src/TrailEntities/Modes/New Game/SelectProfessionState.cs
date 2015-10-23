﻿using System;
using System.Text;
using TrailCommon;

namespace TrailEntities
{
    /// <summary>
    ///     Facilitates the ability for a user to select a given profession for the party leader. This will determine the
    ///     starting amount of money their party has access to when purchasing starting items for the journey on the trail path
    ///     simulation.
    /// </summary>
    public sealed class SelectProfessionState : ModeState<NewGameInfo>
    {
        private StringBuilder professionChooser;

        /// <summary>
        ///     Reference to the total number of professions found in the enumeration.
        /// </summary>
        private int professionCount = 1;

        /// <summary>
        ///     This constructor will be used by the other one
        /// </summary>
        public SelectProfessionState(IMode gameMode, NewGameInfo userData) : base(gameMode, userData)
        {
            // Set the profession to default value in case we are retrying this.
            UserData.PlayerProfession = Profession.Banker;
            UserData.StartingMonies = 1600;

            // Loop through every profession in the enumeration for them and print them in string builder.
            professionChooser = new StringBuilder();
            foreach (var possibleProfession in Enum.GetValues(typeof (Profession)))
            {
                professionChooser.AppendFormat("  {0} - {1}\n", professionCount, possibleProfession);
                professionCount++;
            }

            // Ask the user to make a selection, and then wait for input...
            professionChooser.AppendFormat("What profession is {0}?", UserData.PlayerNames[0]);
        }

        public override string GetStateTUI()
        {
            // Information about professions and how they work.
            var occupationText = new StringBuilder();
            occupationText.Append("You must choose the occupation of the main character.\n");
            occupationText.Append("Various occupations have advantages over one another:\n");
            occupationText.Append("-------------------------------------------------------------------------------\n");
            occupationText.Append("OCCUPATION   | CASH  |  ADVANTAGES                                |FINAL BONUS|\n");
            occupationText.Append("-------------------------------------------------------------------------------\n");
            occupationText.Append("Banker       |$1,600 | none                                       | x1        |\n");
            occupationText.Append("Carpenter    |$800   | more likely to repair broken wagon parts.  | x2        |\n");
            occupationText.Append("Farmer       |$400   | oxen are less likely to get sick and die.  | x3        |\n");
            occupationText.Append("-------------------------------------------------------------------------------\n");
            occupationText.Append("Cash = how much cash a person of that occupation begins with.\n");
            occupationText.Append("Advantages = special individual attributes of the occupation.\n");
            occupationText.Append("Final Bonus = amount that your final point total will be multiplied by.\n\n");

            // Combine instructions with question and selections.
            occupationText.Append(professionChooser);
            return occupationText.ToString();
        }

        public override void OnInputBufferReturned(string input)
        {
            // Once a profession is selected, we need to confirm that is what the user wanted.
            switch (input)
            {
                case "1":
                    UserData.PlayerProfession = Profession.Banker;
                    UserData.StartingMonies = 1600;
                    Mode.CurrentState = new ConfirmProfessionState(Mode, UserData);
                    break;
                case "2":
                    UserData.PlayerProfession = Profession.Carpenter;
                    UserData.StartingMonies = 800;
                    Mode.CurrentState = new ConfirmProfessionState(Mode, UserData);
                    break;
                case "3":
                    UserData.PlayerProfession = Profession.Farmer;
                    UserData.StartingMonies = 400;
                    Mode.CurrentState = new ConfirmProfessionState(Mode, UserData);
                    break;
                default:
                    // If there is some invalid selection just start the process over again.
                    UserData.PlayerProfession = Profession.Banker;
                    UserData.StartingMonies = 1600;
                    Mode.CurrentState = new SelectProfessionState(Mode, UserData);
                    break;
            }
        }
    }
}