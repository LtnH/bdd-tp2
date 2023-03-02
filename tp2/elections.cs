using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace tp2
{
    public class elections
    {
        IEnumerable<candidate> participant;
        bool close = false;
        int totalVote;

        public elections() {
            participant = new List<candidate>();
            totalVote = 0;
        }

        public void SetParticipant(IEnumerable<candidate> newParticipant)
        {
            participant = newParticipant;
        }

        public IEnumerable<candidate> GetParticipant()
        {
            return participant;
        }

        public void setTotalVote(int newTotalVote)
        {
            totalVote = newTotalVote;
        }

        public void closeVote() 
        { 
            close = true;

            foreach (candidate candidate in participant)
            {
                candidate.percentage = ((float)candidate.vote / (float)totalVote * 100f).ToString("0.00");
                Console.WriteLine(candidate.percentage.ToString());
            }
        }

        public bool getClose()
        {
            return close;
        }

        public void openVote()
        {
            close = false;
            participant = new List<candidate>();
        }
        
        public candidate? getWinner()
        {
            candidate winner = participant.Max();

            if (float.Parse(winner.percentage) > 50)
            {
                return winner;
            }
            else
            {
                return null;
            }
        }

        public List<candidate> getSecondTurnCandidate()
        {
            List<candidate> candidate = new List<candidate>();
            candidate.Add(participant.Max());

            candidate.Add(participant.OrderByDescending(participant => participant.percentage).Skip(1).FirstOrDefault());

            return candidate;
        }
    }
}
