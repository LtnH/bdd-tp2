using tp2;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProjectTp2.StepDefinitions
{
    [Binding]
    public class Tp2StepDefinitions
    {
        private readonly elections _elections = new elections(); 

        [Given(@"following candidates and votes")]
        public void GivenFollowingCandidatesAndVotes(Table table)
        {
            var candidate = table.CreateSet<candidate>(returnCandidates);

            _elections.SetParticipant(candidate);
        }

        [Given(@"we have (.*) voters")]
        public void GivenWeHaveVoters(int vote)
        {
            _elections.setTotalVote(vote);
        }

        [Given(@"the vote is open")]
        public void TheVoteIsOpen()
        {
            _elections.openVote();
        }

        [When(@"All voters have voted")]
        public void WhenAllVotersHaveVoted()
        {
            _elections.closeVote();
        }

        [Then(@"the vote closing flag should be true")]
        public void ThenTheVoteClosingFlagShouldBeTrue()
        {
            _elections.getClose().Should().Be(true);
        }

        [Then(@"the winner is (.*) with (.*) percente votes")]
        public void ThenTheWinnerIsWhisPercenteVotes(string name,string vote)
        {
            candidate? result = _elections.getWinner();

            result.Should().NotBeNull();
            result.Name.Should().Be(name);
            result.percentage.Should().Be(vote);
        }
        
        [Then(@"there is no winner")]
        public void ThereIsNoWinner()
        {
            candidate? result = _elections.getWinner();

            result.Should().BeNull();
        }

        [Then(@"the second turn candidate are")]
        public void TheSecondTurnCandidateAre(Table table)
        {
            var candidate = table.CreateSet<candidate>(returnCandidatesResult);

            List<candidate> result = _elections.getSecondTurnCandidate();
            result.Should().NotBeNull();
            result.Should().Equals(candidate);
        }

        [Then(@"the result is")]
        public void TheResultIs(Table table)
        {
            var candidate = table.CreateSet<candidate>(returnCandidatesResult);

            IEnumerable<candidate> result = _elections.GetParticipant();
            result.Should().NotBeNull();
            result.Should().Equals(candidate);
        }

        public candidate returnCandidates(TableRow row)
        {
            return new candidate()
            {
                Name = row["candidates"],
                vote = int.Parse(row["votes"]),
            };
        }
        public candidate returnCandidatesResult(TableRow row)
        {
            return new candidate()
            {
                Name = row["candidates"],
                vote = int.Parse(row["votes"]),
                percentage = row["percentage"]
            };
        }
        
    }
}
