using System;
using ManeraiTest.Backpack.Models;
using ManeraiTest.Backpack.Views;
using ManeraiTest.Input.Models;
using VContainer.Unity;

namespace ManeraiTest.Backpack.Controllers
{
    public class BackpackSelectController : IInitializable, IDisposable
    {
        private readonly BackpackView _backpackView;
        private readonly InputModel _inputModel;
        private readonly BackpackModel _backpackModel;

        private bool _backpackIsSelected;

        public BackpackSelectController(BackpackView backpackView, InputModel inputModel, BackpackModel backpackModel)
        {
            _backpackView = backpackView;
            _inputModel = inputModel;
            _backpackModel = backpackModel;
        }

        public void Initialize()
        {
            _backpackView.Aimed += AimedBackpack;
            _backpackModel.SelectedBackpack += UpdateBackpackSelectionStatus;
            _inputModel.ActionButtonReleased += CheckBackpackDeselected;
        }

        public void Dispose()
        {
            _backpackView.Aimed -= AimedBackpack;
            _backpackModel.SelectedBackpack -= UpdateBackpackSelectionStatus;
            _inputModel.ActionButtonReleased -= CheckBackpackDeselected;
        }

        private void AimedBackpack()
        {
            _backpackModel.OnSelectedBackpack();
        }

        private void UpdateBackpackSelectionStatus()
        {
            _backpackIsSelected = true;
        }

        private void CheckBackpackDeselected()
        {
            if (!_backpackIsSelected)
            {
                return;
            }

            _backpackIsSelected = false;
            _backpackModel.OnDeselectedBackpack();
        }
    }
}