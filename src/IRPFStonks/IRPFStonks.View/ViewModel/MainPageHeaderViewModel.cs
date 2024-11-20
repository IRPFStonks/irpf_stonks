using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRPFStonks.BusinessLogic.Model.Movement;
using IRPFStonks.Inputs;
using IRPFStonks.Inputs.Excel;
using Microsoft.Maui.Storage;
using System.Collections.ObjectModel;

namespace IRPFStonks.View.ViewModel
{
    internal partial class MainPageHeaderViewModel : ObservableValidator
    {
        private FileImporterFactory<StockMovement> fileImporterFactory;
        private readonly IFilePicker filePicker;

        public MainPageHeaderViewModel(IFilePicker filePicker)
        {
            fileImporterFactory = new FileImporterFactory<StockMovement>(new ExcelImporter());
            this.filePicker = filePicker;
        }

        [RelayCommand]
        public async Task LoadFile()
        {
            var file = await filePicker.PickAsync();
            if( file is not null)
            {
                var importResult = await fileImporterFactory.ImportFileAsync(file.FullPath);

                if (importResult.IsSuccessful)
                {
                    StockMovements = new ObservableCollection<StockMovement>(importResult.ImportedData);
                }
            }

        }

        public ObservableCollection<StockMovement> StockMovements { get; private set; }
    }
}
