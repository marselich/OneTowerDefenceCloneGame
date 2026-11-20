using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.ScoreManagment;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenu;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer c)
        {
            c.RegisterAsSingle<MainMenuUIRoot>(CreateMainMenuUIRoot).NonLazy();

            c.RegisterAsSingle<MainMenuPresentersFactory>(CreateMainMenuPresentersFactory);

            c.RegisterAsSingle<MainMenuScreenPresenter>(CreateMainMenuScreenPresenter).NonLazy();

            c.RegisterAsSingle<MainMenuPopupService>(CreateMainMenuPopupService);

            c.RegisterAsSingle<ScoreDisplayer>(CreateScoreDisplayer);
        }

        private static ScoreDisplayer CreateScoreDisplayer(DIContainer c)
         => new ScoreDisplayer(c.Resolve<ScoreCounterService>(), c.Resolve<WalletService>());

        private static MainMenuPopupService CreateMainMenuPopupService(DIContainer c)
            => new MainMenuPopupService(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentersFactory>(),
                c.Resolve<MainMenuPresentersFactory>(),
                c.Resolve<MainMenuUIRoot>());

        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            MainMenuUIRoot mainMenuUIRootPrefab
                = resourcesAssetsLoader.Load<MainMenuUIRoot>("UI/MainMenu/MainMenuUIRoot");

            return Object.Instantiate(mainMenuUIRootPrefab);
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer c)
            => new MainMenuPresentersFactory(c);

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer c)
        {
            MainMenuUIRoot mainMenuUIRoot = c.Resolve<MainMenuUIRoot>();

            MainMenuScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<MainMenuScreenView>(ViewIDs.MainMenuScreenView, mainMenuUIRoot.HUDLayer);

            MainMenuScreenPresenter presenter = c
                .Resolve<MainMenuPresentersFactory>()
                .CreateMainMenuScreenPresenter(view);

            return presenter;
        }
    }
}