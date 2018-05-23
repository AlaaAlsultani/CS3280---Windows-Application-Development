using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A5.Classes
{
    /// <summary>
    /// Class representing a single Math Game
    /// </summary>
    public abstract class Game
    {
        /// <summary>
        /// Players score
        /// </summary>
        public int Score;
        /// <summary>
        /// Player that the game belongs to
        /// </summary>
        public Player Player;
        /// <summary>
        /// Rounds remaining in the game
        /// </summary>
        public int RemRounds;
        /// <summary>
        /// The last timestamp that the user answered a question
        /// </summary>
        public int LastKnownTime;

        /// <summary>
        /// Constructor for a Game. Initializes remaining rounds and time.
        /// </summary>
        /// <param name="p">Player of the game</param>
        public Game(Player p)
        {
            try
            {
                this.Player = p;
                this.RemRounds = 10;
                this.LastKnownTime = 0;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Abstract method to be implemented by child classes to generate their corresponding problems
        /// </summary>
        /// <returns>A Problem object</returns>
        public abstract Problem GenerateProblem();
        /// <summary>
        /// Abstract method to be implemented by child classes to return their corresponding operator
        /// </summary>
        /// <returns>A string representing their operator</returns>
        public abstract string GetOperator();

        /// <summary>
        /// Checks that the user supplied answer equals the solutiont to the problem
        /// </summary>
        /// <param name="p">Problem being answered</param>
        /// <param name="answer">Player's answer</param>
        /// <returns></returns>
        public bool CheckCorrectness(Problem p, int answer)
        {
            try
            {
                return p.GetSolution() == answer;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// If the Player's answer was correct, Calculate their new score and decrement remaining rounds.
        /// Otherwise just decrement remaining rounds.
        /// </summary>
        /// <param name="time">Current game time</param>
        /// <param name="correct">Correctness of the player's answer</param>
        public void UpdateScore(int time, bool correct)
        {
            try
            {
                if (correct)
                {
                    //Time taken to answer this specific question. If greater than 30 treat it as being 30.
                    int adjustedTime = time - LastKnownTime >= 30 ? LastKnownTime + 30 : time - LastKnownTime;
                    //Update to the current time
                    LastKnownTime = time;
                    //Calculate a multiplier to reward lower times
                    int multiplier = 31 - adjustedTime;
                    //Update the score
                    Score += multiplier * 10;
                }
                else
                {
                    //Update to the current time
                    LastKnownTime = time;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
