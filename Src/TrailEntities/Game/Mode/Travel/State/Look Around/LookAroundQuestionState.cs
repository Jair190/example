﻿using System;
using System.Text;
using TrailEntities.Simulation;

namespace TrailEntities.Game
{
    /// <summary>
    ///     State that is attached when the event is fired for reaching a new point of interest on the trail. Default action is
    ///     to ask the player if they would like to look around, but there is a chance for this behavior to be overridden in
    ///     the constructor there is a default boolean value to skip the question asking part and force a look around event to
    ///     occur without player consent.
    /// </summary>
    [RequiredMode(GameMode.Travel)]
    public sealed class LookAroundQuestionState : StateProduct<TravelInfo>
    {
        /// <summary>
        ///     This constructor will be used by the other one
        /// </summary>
        public LookAroundQuestionState(IModeProduct gameMode) : base(gameMode)
        {
        }

        /// <summary>
        ///     Returns a text only representation of the current game mode state. Could be a statement, information, question
        ///     waiting input, etc.
        /// </summary>
        public override string OnRenderState()
        {
            // Wait for input on deciding if we should take a look around.
            var pointReached = new StringBuilder();
            pointReached.Append($"You are now at the {ParentMode.CurrentPoint.Name}.{Environment.NewLine}");
            pointReached.Append("Would you like to look around? Y/N");
            return pointReached.ToString();
        }

        /// <summary>
        ///     Fired when the game mode current state is not null and input buffer does not match any known command.
        /// </summary>
        /// <param name="input">Contents of the input buffer which didn't match any known command in parent game mode.</param>
        public override void OnInputBufferReturned(string input)
        {
            // If use wants to look around attach that mode, other wise just remove current state and go back to travel mode.
            switch (input.ToUpperInvariant())
            {
                case "Y":
                    //parentGameMode.CurrentState = new LookAroundState(parentGameMode, UserData);
                    SetState(typeof (LookAroundState));
                    break;
                default:
                    //parentGameMode.CurrentState = null;
                    ClearState();
                    break;
            }
        }
    }
}