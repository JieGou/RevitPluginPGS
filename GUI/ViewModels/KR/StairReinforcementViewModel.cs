﻿using Autodesk.Revit.DB.Structure;
using MS.GUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.GUI.ViewModels.KR
{
    public class StairReinforcementViewModel : ViewModelBase
    {
        /// <summary>
        /// Коллекция типов арматурных стержней для каркасов ступеней
        /// </summary>
        public ObservableCollection<RebarBarType> RebarTypesSteps { get; }

        /// <summary>
        /// Тип арматурных стержней каркаса лестницы
        /// </summary>
        private static RebarBarType _selectedRebarTypeSteps;

        /// <summary>
        /// Выбранный тип арматурного стержня для каркаса ступени
        /// </summary>
        public RebarBarType SelectedRebarTypeSteps
        {
            get => _selectedRebarTypeSteps;
            set => Set(ref _selectedRebarTypeSteps, value);
        }


        /// <summary>
        /// Коллекция типов арматурных стержней для рабочей арматуры марша
        /// </summary>
        public ObservableCollection<RebarBarType> RebarTypesMain { get; }

        /// <summary>
        /// Тип рабочих арматурных стержней лестничного марша
        /// </summary>
        private static RebarBarType _selectedRebarTypeMain;

        /// <summary>
        /// Выбранный тип арматурного стержня для каркаса ступени
        /// </summary>
        public RebarBarType SelectedRebarTypeMain
        {
            get => _selectedRebarTypeMain;
            set => Set(ref _selectedRebarTypeMain, value);
        }


        /// <summary>
        /// Защитный слой арматурных стержней каркасов ступеней
        /// </summary>
        private static int _rebarCoverSteps;

        /// <summary>
        /// Защитный слой арматурных стержней каркасов ступеней
        /// </summary>
        [RegexStringValidator(@"^[1-7][0-9]$")]
        public int RebarCoverSteps
        {
            get => _rebarCoverSteps;
            set => Set(ref _rebarCoverSteps, value);
        }


        /// <summary>
        /// Защитный слой рабочих арматурных стержней марша по наклонной грани
        /// </summary>
        private static int _rebarCoverMainAngle;

        /// <summary>
        /// Защитный слой рабочих арматурных стержней марша по наклонной грани
        /// </summary>
        [RegexStringValidator(@"^[1-7][0-9]$")]
        public int RebarCoverMainAngle
        {
            get => _rebarCoverMainAngle;
            set => Set(ref _rebarCoverMainAngle, value);
        }


        /// <summary>
        /// Защитный слой рабочих арматурных стержней марша по горизонтальным граням
        /// </summary>
        private static int _rebarCoverMainHoriz;

        /// <summary>
        /// Защитный слой рабочих арматурных стержней марша по горизонтальным граням
        /// </summary>
        [RegexStringValidator(@"^[1-7][0-9]$")]
        public int RebarCoverMainHoriz
        {
            get => _rebarCoverMainHoriz;
            set => Set(ref _rebarCoverMainHoriz, value);
        }


        /// <summary>
        /// Шаг Г- стержней каркасов ступеней
        /// </summary>
        private static int _barsStepStepsHorizont;

        /// <summary>
        /// Шаг Г- стержней каркасов ступеней
        /// </summary>
        [RegexStringValidator(@"^[1-9][0-9]{2}$")]
        public int BarsStepStepsHorizont
        {
            get => _barsStepStepsHorizont;
            set => Set(ref _barsStepStepsHorizont, value);
        }


        /// <summary>
        /// Шаг горизонтальных стержней каркасов ступеней
        /// </summary>
        private static int _barsStepStepsVert;

        /// <summary>
        /// Шаг горизонтальных стержней каркасов ступеней
        /// </summary>
        [RegexStringValidator(@"^[1-9][0-9]{2}$")]
        public int BarsStepStepsVert
        {
            get => _barsStepStepsVert;
            set => Set(ref _barsStepStepsVert, value);
        }


        /// <summary>
        /// Шаг поперечных горизонтальных стержней марша
        /// </summary>
        private static int _barsStepMainHorizont;

        /// <summary>
        /// Шаг поперечных горизонтальных стержней марша
        /// </summary>
        [RegexStringValidator(@"^[1-9][0-9]{2}$")]
        public int BarsStepMainHorizont
        {
            get => _barsStepMainHorizont;
            set => Set(ref _barsStepMainHorizont, value);
        }


        /// <summary>
        /// Шаг рабочих продольных Z - стержней марша
        /// </summary>
        private static int _barsStepMainAngle;

        /// <summary>
        /// Шаг рабочих продольных Z - стержней марша
        /// </summary>
        [RegexStringValidator(@"^[1-9][0-9]{2}$")]
        public int BarsStepMainAngle
        {
            get => _barsStepMainAngle;
            set => Set(ref _barsStepMainAngle, value);
        }
    }
}
