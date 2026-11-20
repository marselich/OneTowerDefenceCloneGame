using Assets._Project.Develop.Runtime.Configs.Gameplay.Score;
using Assets._Project.Develop.Runtime.Meta.Features.ScoreManagment;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.Interfaces;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Score
{
    public class ScorePresenter : IPresenter
    {
        private readonly ScoreCounterService _scoreCounterService;
        private readonly ViewsFactory _viewsFactory;
        private readonly ScoreIconsConfig _scoreIconsConfig;

        private readonly IconTextListView _view;

        private IconTextView _winsView;
        private IconTextView _losesView;
        private List<IDisposable> _disposable = new();

        public ScorePresenter(
            ScoreCounterService scoreCounterService,
            ViewsFactory viewsFactory,
            ScoreIconsConfig scoreIconsConfig,
            IconTextListView view)
        {
            _scoreCounterService = scoreCounterService;
            _viewsFactory = viewsFactory;
            _scoreIconsConfig = scoreIconsConfig;
            _view = view;
        }

        public void Initialize()
        {
            _winsView = _viewsFactory.Create<IconTextView>(ViewIDs.IconTextView);
            _losesView = _viewsFactory.Create<IconTextView>(ViewIDs.IconTextView);

            AddView(_winsView, _scoreCounterService.WinCount, _scoreIconsConfig.WinsSprite, OnWinsChanged);
            AddView(_losesView, _scoreCounterService.LoseCount, _scoreIconsConfig.LosesSprite, OnLosesChanged);
        }

        public void Dispose()
        {
            foreach (IDisposable disposable in _disposable)
                disposable.Dispose();
        }

        private void AddView(IconTextView view, IReadOnlyVariable<int> value, Sprite sprite, Action<int, int> onChanged)
        {
            _view.Add(view);

            UpdateValue(view, value.Value);

            view.SetIcon(sprite);

            _disposable.Add(value.Subscribe(onChanged));
        }

        private void OnWinsChanged(int arg1, int newValue) => UpdateValue(_winsView, newValue);
        private void OnLosesChanged(int arg1, int newValue) => UpdateValue(_losesView, newValue);

        private void UpdateValue(IconTextView view, int value) => view.SetText(value.ToString());
    }
}