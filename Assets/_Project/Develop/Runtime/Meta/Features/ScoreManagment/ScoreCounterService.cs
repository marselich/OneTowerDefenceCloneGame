using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Meta.Features.ScoreManagment
{
    public class ScoreCounterService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private ReactiveVariable<int> _winCount = new();
        private ReactiveVariable<int> _loseCount = new();

        public ScoreCounterService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public IReadOnlyVariable<int> WinCount => _winCount;

        public IReadOnlyVariable<int> LoseCount => _loseCount;

        public void AddWin() => _winCount.Value++;

        public void AddLose() => _loseCount.Value++;

        public void Reset()
        {
            _winCount.Value = 0;
            _loseCount.Value = 0;
        }

        public void ReadFrom(PlayerData data)
        {
            _winCount.Value = data.WinCount;
            _loseCount.Value = data.LoseCount;
        }

        public void WriteTo(PlayerData data)
        {
            data.WinCount = _winCount.Value;
            data.LoseCount = _loseCount.Value;
        }
    }
}