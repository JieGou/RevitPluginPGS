﻿using MS.Commands.MEP.Mechanic;
using MS.Commands.MEP.Mechanic.Impl;
using MS.Commands.MEP.Models;
using MS.Commands.MEP.Models.Installation;
using MS.Commands.MEP.Models.Symbolic;
using MS.GUI.CommandsBase;
using MS.GUI.ViewModels.Base;
using MS.GUI.Windows.MEP;
using MS.GUI.Windows.MEP.InstallationConstructor;
using MS.GUI.Windows.MEP.InstallationConstructor.MechanicViews;
using MS.Utilites;
using MS.Utilites.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MS.GUI.ViewModels.MEP.DuctInstallation
{
    public class DuctEquipmentConstructorViewModel : ViewModelBase
    {
        public DuctEquipmentConstructorViewModel()
        {
        }


        /// <summary>
        /// Ширина установки
        /// </summary>
        private double _width;

        /// <summary>
        /// Ширина установки
        /// </summary>
        public double Width
        {
            get => _width;
            set => Set(ref _width, value);
        }

        /// <summary>
        /// Высота установки
        /// </summary>
        private double _height;

        /// <summary>
        /// Высота установки
        /// </summary>
        public double Height { get => _height; set => Set(ref _height, value); }

        /// <summary>
        /// Полное название установки
        /// </summary>
        private string _nameLong;

        /// <summary>
        /// Полное название установки
        /// </summary>
        public string NameLong
        {
            get => _nameLong;
            set => Set(ref _nameLong, value);
        }


        /// <summary>
        /// Сокращенное наименование установки
        /// </summary>
        private string _nameShort;

        /// <summary>
        /// Сокращенное наименование установки
        /// </summary>
        public string NameShort
        {
            get => _nameShort;
            set => Set(ref _nameShort, value);
        }


        /// <summary>
        /// Наименование системы
        /// </summary>
        private string _systemName;

        /// <summary>
        /// Наименование системы
        /// </summary>
        public string SystemName
        {
            get => _systemName;
            set => Set(ref _systemName, value);
        }


        /// <summary>
        /// Тип установки
        /// </summary>
        private string _type;

        /// <summary>
        /// Тип установки
        /// </summary>
        public string Type
        {
            get => _type;
            set => Set(ref _type, value);
        }


        /// <summary>
        /// Впуск высота
        /// </summary>
        private double _inputHeight;

        /// <summary>
        /// Впуск высота
        /// </summary>
        public double InputHeight
        {
            get => _inputHeight;
            set => Set(ref _inputHeight, value);
        }

        /// <summary>
        /// Впуск ширина
        /// </summary>
        private double _inputWidth;

        /// <summary>
        /// Впуск ширина
        /// </summary>
        public double InputWidth
        {
            get => _inputWidth;
            set => Set(ref _inputWidth, value);
        }

        /// <summary>
        /// Впуск высота
        /// </summary>
        private double _inputLength;

        /// <summary>
        /// Впуск высота
        /// </summary>
        public double InputLength
        {
            get => _inputLength;
            set => Set(ref _inputLength, value);
        }

        /// <summary>
        /// Выпуск высота
        /// </summary>
        private double _outputHeight;

        /// <summary>
        /// Выпуск высота
        /// </summary>
        public double OutputHeight
        {
            get => _outputHeight;
            set => Set(ref _outputHeight, value);
        }

        /// <summary>
        /// Отображает полученную конфигурацию установки
        /// </summary>
        /// <param name="viewModel">Конфигурация установки</param>
        public void LoadViewModel(DuctEquipmentConstructorViewModel viewModel)
        {
            Width = viewModel.Width;
            Height = viewModel.Height;
            Type = viewModel.Type;
            SystemName = viewModel.SystemName;
            NameLong = viewModel.NameLong;
            NameShort = viewModel.NameShort;
            InputHeight = viewModel.InputHeight;
            InputWidth = viewModel.InputWidth;
            InputLength = viewModel.InputLength;
            InputLocationBottom = viewModel.InputLocationBottom;
            OutputHeight = viewModel.OutputHeight;
            OutputLength = viewModel.OutputLength;
            OutputWidth = viewModel.OutputWidth;
            OutputLocationBottom = viewModel.OutputLocationBottom;

            Fillings.Clear();
            foreach (var filling in viewModel.Fillings)
            {
                Fillings.Add(filling);
            }

            Mechanics.Clear();
            foreach (var mechanic in viewModel.Mechanics)
            {
                Mechanics.Add(mechanic);
            }

            Symbolics.Clear();
            foreach (var symbolic in viewModel.Symbolics)
            {
                Symbolics.Add(symbolic);
            }
        }

        /// <summary>
        /// Возвращает установку, сконструированную пользователем
        /// </summary>
        /// <returns></returns>
        public Installation GetInstallation()
        {
            Installation installation = new Installation(Width, Height)
            {
                InputHeight = InputHeight,
                InputLength = InputLength,
                InputWidth = InputWidth,
                InputLocationBottom = InputLocationBottom ? 1 : 0,
                InputLocationMiddle = InputLocationBottom ? 0 : 1,
                OutputHeight = OutputHeight,
                OutputLength = OutputLength,
                OutputWidth = OutputWidth,
                OutputLocationBottom = OutputLocationBottom ? 1 : 0,
                OutputLocationMiddle = OutputLocationBottom ? 0 : 1,
                Name = NameLong,
                NameShort = NameShort,
                System = SystemName,
                Type = Type
            };
            installation.AddFilling(Fillings);
            installation.AddMechanic(Mechanics);
            installation.AddSymbolic(Symbolics);
            return installation;
        }

        /// <summary>
        /// Выпуск ширина
        /// </summary>
        private double _outputWidth;

        /// <summary>
        /// Выпуск ширина
        /// </summary>
        public double OutputWidth
        {
            get => _outputWidth;
            set => Set(ref _outputWidth, value);
        }

        /// <summary>
        /// Выпуск длина
        /// </summary>
        private double _outputLength;

        /// <summary>
        /// Выпуск длина
        /// </summary>
        public double OutputLength
        {
            get => _outputLength;
            set => Set(ref _outputLength, value);
        }


        /// <summary>
        /// Впуск снизу
        /// </summary>
        private bool _inputLocationBottom;

        /// <summary>
        /// Впуск снизу
        /// </summary>
        public bool InputLocationBottom
        {
            get => _inputLocationBottom;
            set => Set(ref _inputLocationBottom, value);
        }

        /// <summary>
        /// Выпуск снизу
        /// </summary>
        private bool _outputLocationBottom;

        /// <summary>
        /// Выпуск снизу
        /// </summary>
        public bool OutputLocationBottom
        {
            get => _outputLocationBottom;
            set => Set(ref _outputLocationBottom, value);
        }


        /// <summary>
        /// Коллекция элементов оборудования в установке
        /// </summary>
        public ObservableCollection<Mechanic> Mechanics { get; private set; } = new ObservableCollection<Mechanic>();

        /// <summary>
        /// Выбранное оборудование
        /// </summary>
        private Mechanic _selectedMechanic;

        /// <summary>
        /// Выбранное оборудование
        /// </summary>
        public Mechanic SelectedMechanic
        {
            get => _selectedMechanic;
            set
            {
                if (value is null)
                {
                    Set(ref _selectedMechanic, Mechanics.FirstOrDefault());
                }
                else
                {
                    Set(ref _selectedMechanic, value);
                }
            }
        }


        /// <summary>
        /// Коллекция элементов наполнения в установке
        /// </summary>
        public ObservableCollection<Filling> Fillings { get; private set; } = new ObservableCollection<Filling>();

        /// <summary>
        /// Выбранное наполнение
        /// </summary>
        private Filling _selectedFilling;

        /// <summary>
        /// Выбранное наполнение
        /// </summary>
        public Filling SelectedFilling
        {
            get => _selectedFilling;
            set
            {
                if (value is null)
                {
                    Set(ref _selectedFilling, Fillings.FirstOrDefault());
                }
                else
                {
                    Set(ref _selectedFilling, value);
                }
            }
        }


        /// <summary>
        /// Коллекция элементов УГО в установке
        /// </summary>
        public ObservableCollection<Symbolic> Symbolics { get; private set; } = new ObservableCollection<Symbolic>();

        /// <summary>
        /// Выбранное УГО
        /// </summary>
        private Symbolic _selectedSymbolic;

        /// <summary>
        /// Выбранное УГО
        /// </summary>
        public Symbolic SelectedSymbolic
        {
            get => _selectedSymbolic;
            set
            {
                if (value is null)
                {
                    Set(ref _selectedSymbolic, Symbolics.FirstOrDefault());
                }
                else
                {
                    Set(ref _selectedSymbolic, value);
                }
            }
        }

        /// <summary>
        /// Стартовая директория для работы с сериализованными установками
        /// </summary>
        private static string @_serializationStartPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        /// <summary>
        /// Сериализует объект установки в JSON в указанную директорию с названием, соответствующим названию системы.
        /// </summary>
        /// <param name="installation">Сериализуемая установка</param>
        private string SerializeViewModel()
        {
            var filePath = WorkWithPath.GetFilePath(
                ref @_serializationStartPath,
                "Json файлы (*.json)|*.json|Текстовые файлы (*.txt)|*.txt",
                "Перейдите в папку и напишите название файла без расширения",
                string.Empty);

            string jsonString = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, jsonString);
            return filePath;
        }


        /// <summary>
        /// Десериализует установку из указанного файла
        /// </summary>
        /// <param name="filePath">JSON файл установки</param>
        /// <returns>Десериализованный объект установки</returns>
        private DuctEquipmentConstructorViewModel DeserializeViewModel()
        {
            var filePath = $@"{WorkWithPath.GetFilePath(
                ref @_serializationStartPath,
                "Json файлы (*.json)|*.json|Текстовые файлы (*.txt)|*.txt",
                "Выберите Json файл с вентиляционной установкой",
                string.Empty)}";

            string jsonString = File.ReadAllText(@filePath);
            return JsonConvert.DeserializeObject<DuctEquipmentConstructorViewModel>(jsonString);
        }


        #region Commands for Serialization Deserialization

        #region Serialize

        private ICommand _serialize;

        public ICommand Serizlize
            => _serialize = _serialize ?? new LambdaCommand(OnSerializeCommandExecuted, CanSerializeCommandExecute);

        private bool CanSerializeCommandExecute(object p) => true;

        private void OnSerializeCommandExecuted(object p)
        {
            SerializeViewModel();
        }
        #endregion

        #region Deserialize

        private ICommand _deserialize;

        public ICommand Deserialize
            => _deserialize = _deserialize ?? new LambdaCommand(OnDeserializationCommandExecuted, CanDeserializeCommandExecute);

        private bool CanDeserializeCommandExecute(object p) => true;

        private void OnDeserializationCommandExecuted(object p)
        {
            DuctEquipmentConstructorViewModel viewModel = DeserializeViewModel();
            LoadViewModel(viewModel);
        }

        #endregion

        #endregion

        #region Commands for Mechanic

        #region Create Mechanic command

        /// <summary>
        /// Команда добавления оборудования
        /// </summary>
        private ICommand _createNewMechanicCommand;

        /// <summary>
        /// Команда добавления оборудования
        /// </summary>
        public ICommand CreateNewMechanicCommand
            => _createNewMechanicCommand = _createNewMechanicCommand ?? new LambdaCommand(OnCreateNewMechanicCommandExecuted, CanCreateNewMechanicCommandExecute);

        /// <summary>
        /// Оборудование можно добавить всегда
        /// </summary>
        /// <param name="p">Передаваемый объект</param>
        /// <returns></returns>
        private static bool CanCreateNewMechanicCommandExecute(object p) => true;

        /// <summary>
        /// Действие при добавлении нового оборудования
        /// </summary>
        /// <param name="p"></param>
        private void OnCreateNewMechanicCommandExecuted(object p)
        {
            var ui = new ChooseMechanicTypeView()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            ui.ShowDialog();
            ChooseMechanicTypeViewModel vm = ui.DataContext as ChooseMechanicTypeViewModel;
            if (ui.DialogResult == true && !string.IsNullOrEmpty(vm.SelectedMechanicType))
            {
                switch (vm.EquipmentType)
                {
                    case Commands.MEP.Enums.EquipmentType.Fan:
                        FanView fanView = new FanView() { WindowStartupLocation = WindowStartupLocation.CenterOwner };
                        fanView.ShowDialog();
                        if (fanView.DialogResult == true)
                        {
                            Mechanics.Add((fanView.DataContext as FanViewModel).GetFan());
                        }
                        break;
                    case Commands.MEP.Enums.EquipmentType.AirCooler:
                        CoolerView coolerView = new CoolerView() { WindowStartupLocation = WindowStartupLocation.CenterOwner };
                        coolerView.ShowDialog();
                        if (coolerView.DialogResult == true)
                        {
                            Mechanics.Add((coolerView.DataContext as CoolerViewModel).GetCooler());
                        }
                        break;
                    case Commands.MEP.Enums.EquipmentType.AirHeater:
                        HeaterView heaterView = new HeaterView() { WindowStartupLocation = WindowStartupLocation.CenterOwner };
                        heaterView.ShowDialog();
                        if (heaterView.DialogResult == true)
                        {
                            Mechanics.Add((heaterView.DataContext as HeaterViewModel).GetHeater());
                        }
                        break;
                    case Commands.MEP.Enums.EquipmentType.Filter:
                        FilterView filterView = new FilterView() { WindowStartupLocation = WindowStartupLocation.CenterOwner };
                        filterView.ShowDialog();
                        if (filterView.DialogResult == true)
                        {
                            Mechanics.Add((filterView.DataContext as FilterViewModel).GetFilter());
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Edit Mechanic command
        /// <summary>
        /// Команда редактирования оборудования
        /// </summary>
        private ICommand _editMechanicCommand;

        /// <summary>
        /// Команда редактирования оборудования
        /// </summary>
        public ICommand EditMechanicCommand
            => _editMechanicCommand = _editMechanicCommand ?? new LambdaCommand(OnEditMechanicCommandExecuted, CanEditMechanicCommandExecute);

        /// <summary>
        /// Проверка возможности выполнения команды редактирования оборудования
        /// </summary>
        /// <param name="p">Объект для редактирования</param>
        /// <returns></returns>
        private static bool CanEditMechanicCommandExecute(object p) => p is Mechanic;

        /// <summary>
        /// Действие, при редактировании оборудования
        /// </summary>
        /// <param name="p">Объект для редактирвоания</param>
        private void OnEditMechanicCommandExecuted(object p)
        {
            var mechanic = (Mechanic)p;
            switch (mechanic.EquipmentType)
            {
                case Commands.MEP.Enums.EquipmentType.Fan:
                    FanViewModel fanVM = new FanViewModel((Fan)mechanic);
                    FanView fanView = new FanView() { DataContext = fanVM, WindowStartupLocation = WindowStartupLocation.CenterOwner };
                    fanView.ShowDialog();
                    if (fanView.DialogResult == true)
                    {
                        Mechanics.UpdateEntity((fanView.DataContext as FanViewModel).GetFan(mechanic.Guid));
                    }
                    break;
                case Commands.MEP.Enums.EquipmentType.AirCooler:
                    var t = 0;
                    Cooler test = mechanic as Cooler;
                    CoolerViewModel coolerVM = new CoolerViewModel((Cooler)mechanic);
                    CoolerView coolerView = new CoolerView() { DataContext = coolerVM, WindowStartupLocation = WindowStartupLocation.CenterOwner };
                    coolerView.ShowDialog();
                    if (coolerView.DialogResult == true)
                    {
                        Mechanics.UpdateEntity((coolerView.DataContext as CoolerViewModel).GetCooler(mechanic.Guid));
                    }
                    break;
                case Commands.MEP.Enums.EquipmentType.AirHeater:
                    HeaterViewModel heaterVM = new HeaterViewModel((Heater)mechanic);
                    HeaterView heaterView = new HeaterView() { DataContext = heaterVM, WindowStartupLocation = WindowStartupLocation.CenterOwner };
                    heaterView.ShowDialog();
                    if (heaterView.DialogResult == true)
                    {
                        Mechanics.UpdateEntity((heaterView.DataContext as HeaterViewModel).GetHeater(mechanic.Guid));
                    }
                    break;
                case Commands.MEP.Enums.EquipmentType.Filter:
                    FilterViewModel filterVM = new FilterViewModel((Filter)mechanic);
                    FilterView filterView = new FilterView() { DataContext = filterVM, WindowStartupLocation = WindowStartupLocation.CenterOwner };
                    filterView.ShowDialog();
                    if (filterView.DialogResult == true)
                    {
                        Mechanics.UpdateEntity((filterView.DataContext as FilterViewModel).GetFilter(mechanic.Guid));
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Delete command
        /// <summary>
        /// Команда удаления оборудования
        /// </summary>
        private ICommand _deleteMechanicCommand;

        /// <summary>
        /// Команда удаления оборудования
        /// </summary>
        public ICommand DeleteMechanicCommand
            => _deleteMechanicCommand = _deleteMechanicCommand ?? new LambdaCommand(OnDeleteMechanicCommandExecuted, CanDeleteMechanicCommandExecute);

        /// <summary>
        /// Элемент можно удалить из списка оборудования всегда
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool CanDeleteMechanicCommandExecute(object p) => true;

        /// <summary>
        /// Действие при удалении оборудования
        /// </summary>
        /// <param name="p"></param>
        private void OnDeleteMechanicCommandExecuted(object p)
        {
            //write
            Mechanic mechanic = (Mechanic)p;
            Mechanics.Remove(mechanic);
        }
        #endregion

        #endregion

        #region Commands for Filling

        #region Create Filling command

        /// <summary>
        /// Команда добавления наполнения
        /// </summary>
        private ICommand _createNewFillingCommand;

        /// <summary>
        /// Команда добавления наполнения
        /// </summary>
        public ICommand CreateNewFillingCommand
            => _createNewFillingCommand = _createNewFillingCommand ?? new LambdaCommand(OnCreateNewFillingCommandExecuted, CanCreateNewFillingCommandExecute);

        /// <summary>
        /// Наполнение можно добавить всегда
        /// </summary>
        /// <param name="p">Передаваемый объект</param>
        /// <returns></returns>
        private static bool CanCreateNewFillingCommandExecute(object p) => true;

        /// <summary>
        /// Действие при добавлении нового наполнения
        /// </summary>
        /// <param name="p"></param>
        private void OnCreateNewFillingCommandExecuted(object p)
        {
            //write
            Fillings.Add(new Filling("new name"));
        }

        #endregion

        #region Delete Filling command

        /// <summary>
        /// Команда удаления наполнения
        /// </summary>
        private ICommand _deleteFillingCommand;

        /// <summary>
        /// Команда удаления наполнения
        /// </summary>
        public ICommand DeleteFillingCommand
            => _deleteFillingCommand = _deleteFillingCommand ?? new LambdaCommand(OnDeleteFillingCommandExecuted, CanDeleteFillingCommandExecute);

        /// <summary>
        /// Элемент можно удалить из списка наполнения всегда
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool CanDeleteFillingCommandExecute(object p) => true;

        /// <summary>
        /// Действие при удалении наполнения
        /// </summary>
        /// <param name="p"></param>
        private void OnDeleteFillingCommandExecuted(object p)
        {
            //write
            Filling mechanic = (Filling)p;
            Fillings.Remove(mechanic);
        }

        #endregion

        #endregion

        #region Commands for Symbolic

        #region Create Symbolic command

        /// <summary>
        /// Команда добавления УГО
        /// </summary>
        private ICommand _createNewSymbolicCommand;

        /// <summary>
        /// Команда добавления УГО
        /// </summary>
        public ICommand CreateNewSymbolicCommand
            => _createNewSymbolicCommand = _createNewSymbolicCommand ?? new LambdaCommand(OnCreateNewSymbolicCommandExecuted, CanCreateNewSymbolicCommandExecute);

        /// <summary>
        /// Оборудование можно добавить, если передаваемый объект - УГО
        /// </summary>
        /// <param name="p">Передаваемый объект</param>
        /// <returns></returns>
        private static bool CanCreateNewSymbolicCommandExecute(object p) => true;

        /// <summary>
        /// Действие при добавлении нового УГО
        /// </summary>
        /// <param name="p"></param>
        private void OnCreateNewSymbolicCommandExecuted(object p)
        {
            //write
            Symbolics.Add(new Symbolic());
        }

        #endregion

        #region Delete Symbolic command

        /// <summary>
        /// Команда удаления УГО
        /// </summary>
        private ICommand _deleteSymbolicCommand;

        /// <summary>
        /// Команда удаления УГО
        /// </summary>
        public ICommand DeleteSymbolicCommand
            => _deleteSymbolicCommand = _deleteSymbolicCommand ?? new LambdaCommand(OnDeleteSymbolicCommandExecuted, CanDeleteSymbolicCommandExecute);

        /// <summary>
        /// Элемент можно удалить из списка УГО всегда
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool CanDeleteSymbolicCommandExecute(object p) => true;

        /// <summary>
        /// Действие при удалении УГО
        /// </summary>
        /// <param name="p"></param>
        private void OnDeleteSymbolicCommandExecuted(object p)
        {
            //write
            Symbolic mechanic = (Symbolic)p;
            Symbolics.Remove(mechanic);
        }

        #endregion

        #region Convert to Mechanic and Filling command

        /// <summary>
        /// Копирование элементов из списка УГО в спискки оборудования и наполнения
        /// </summary>
        private ICommand _convertToMechanicAndFilling;

        /// <summary>
        /// Копирование элементов из списка УГО в спискки оборудования и наполнения
        /// </summary>
        public ICommand ConvertToMechanicAndFillingCommand
            => _convertToMechanicAndFilling = _convertToMechanicAndFilling ?? new LambdaCommand(OnConvertToMechanicAndFillingCommandExecuted, CanConvertToMechanicAndFillingCommandExecute);

        /// <summary>
        /// Команду можно выполнить, только если списки оборудвоания и наполнения пустые
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool CanConvertToMechanicAndFillingCommandExecute(object p)
        {
            return (Fillings.Count + Mechanics.Count) == 0;
        }

        /// <summary>
        /// Копирование заполненных элементов из списка УГО в списки наполнения и оборудования
        /// </summary>
        /// <param name="p"></param>
        private void OnConvertToMechanicAndFillingCommandExecuted(object p)
        {
            foreach (var item in Symbolics)
            {
                switch (item.Name)
                {
                    case "Вентилятор":
                        Mechanics.Add(new Fan(item.Length));
                        break;
                    case "Воздухонагреватель водяной":
                    case "Воздухонагреватель электрический":
                        Mechanics.Add(new Heater(item.Length));
                        break;
                    case "Воздухоохладитель водяной":
                    case "Воздухоохладитель электрический":
                        Mechanics.Add(new Cooler(item.Length));
                        break;
                    case "Фильтр":
                        Mechanics.Add(new Filter(item.Length));
                        break;
                    case "Шумоглушитель":
                        Fillings.Add(new Filling(item.Name));
                        break;
                    default:
                        break;
                }
            };
        }

        #endregion

        #region MoveUp command

        /// <summary>
        /// Передвижение элемента списка на 1 позицию ближе к началу списка
        /// </summary>
        private ICommand _moveUp;

        /// <summary>
        /// Передвижение элемента списка на 1 позицию ближе к началу списка
        /// </summary>
        public ICommand MoveUpCommand
            => _moveUp = _moveUp ?? new LambdaCommand(OnMoveUpCommandExecuted, CanMoveUpCommandExecute);

        /// <summary>
        /// Команду можно выполнить, только если выбранный элемент не первый
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool CanMoveUpCommandExecute(object p)
        {
            var symbolic = (Symbolic)p;
            return !(symbolic is null) && Symbolics.IndexOf(symbolic) > 0;
        }

        /// <summary>
        /// Передвижение элемента списка на 1 позицию ближе к началу списка
        /// </summary>
        /// <param name="p"></param>
        private void OnMoveUpCommandExecuted(object p)
        {
            var indexFrom = Symbolics.IndexOf((Symbolic)p);
            var indexTo = indexFrom - 1;
            var temp = Symbolics[indexTo];
            Symbolics[indexTo] = Symbolics[indexFrom];
            Symbolics[indexFrom] = temp;
            SelectedSymbolic = Symbolics[indexTo];
        }
        #endregion

        #region MoveDown Command

        /// <summary>
        /// Передвинуть элемент на 1 поизцию ближе к концу списка
        /// </summary>
        private ICommand _moveDown;

        /// <summary>
        /// Передвинуть элемент на 1 поизцию ближе к концу списка
        /// </summary>
        public ICommand MoveDownCommand
            => _moveDown = _moveDown ?? new LambdaCommand(OnMoveDownCommandExecuted, CanMoveDownCommandExecute);

        /// <summary>
        /// Команду можно выполнить, только если выбранный элемент не последний
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool CanMoveDownCommandExecute(object p)
        {
            var symbolic = (Symbolic)p;
            return !(symbolic is null) && Symbolics.IndexOf(symbolic) < Symbolics.Count - 1;
        }

        /// <summary>
        /// Передвижение элемента на 1 позицию ближе к концу списка
        /// </summary>
        /// <param name="p"></param>
        private void OnMoveDownCommandExecuted(object p)
        {
            var indexFrom = Symbolics.IndexOf((Symbolic)p);
            var indexTo = indexFrom + 1;
            var temp = Symbolics[indexTo];
            Symbolics[indexTo] = Symbolics[indexFrom];
            Symbolics[indexFrom] = temp;
            SelectedSymbolic = Symbolics[indexTo];
        }

        #endregion

        #endregion
    }
}
