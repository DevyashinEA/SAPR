using System;
using System.Collections.Generic;

namespace HangarModel
{
    /// <summary>
    /// Класс HangarParam хранит параметры ангара, выбрасывая ошибку при введении параметров за пределы допустимого.
    /// </summary>
    public class HangarParam
    {
        /// <summary>
        /// Коэф надёжности строения.
        /// </summary>
        const double _safetyFactor = 1.2;
        /// <summary>
        /// Удельный вес профлиста крыши.
        /// </summary>
        const int _specificGravityOfProfiledSheet = 50;
        /// <summary>
        /// Удельные вес стальных листов стен и ворот.
        /// </summary>
        const int _specificGravityOfSteelSheet = 60;
        /// <summary>
        /// Удельный вес железобетонного фундамента и подстенки (подошвы).
        /// </summary>
        const int _specificGravityOfReinforcedConcrete = 2500;
        /// <summary>
        /// Снеговая нагрузка.
        /// </summary>
        private int _seasonalSnowLoads = 400;
        /// <summary>
        /// Длина сваи.
        /// </summary>
        private double _heightPiles;
        /// <summary>
        /// Число свай.
        /// </summary>
        private int _quantityPiles;
        /// <summary>
        /// Высота ангара.
        /// </summary>
        private double _hangarHeight;
        /// <summary>
        /// Ширина ангара.
        /// </summary>
        private double _hangarWidth;
        /// <summary>
        /// Длина ангара
        /// </summary>
        private double _hangarLength;
        /// <summary>
        /// Высота ворот
        /// </summary>
        private double _gateHeight;
        /// <summary>
        /// Ширина ворот
        /// </summary>
        private double _gateWidth;
        /// <summary>
        /// Высота стены(подошвы фундамента)
        /// </summary>
        private double _wallHeight;
        /// <summary>
        /// Первый слой грунта
        /// </summary>
        private Soil _firstSoil = new Soil();
        /// <summary>
        /// Второй слой грунта
        /// </summary>
        private Soil _secondSoil = new Soil();
        /// <summary>
        /// Третий слой грунта
        /// </summary>
        private Soil _thirdSoil = new Soil();
        /// <summary>
        /// Словарь ограничений для параметров ангара
        /// </summary>
        Dictionary<string, double[]> _sizeRestrictions = new Dictionary<string, double[]>();
        /// <summary>
        /// Словарь названий для параметров ангара
        /// </summary>
        Dictionary<string, string> _nameRestrictions = new Dictionary<string, string>();

        /// <summary>
        /// Функция добавляющая в словарь ограничения для параметров ангара.
        /// </summary>
        public HangarParam()
        {
            _sizeRestrictions.Add("HangarHeight", new double[2] { 2, 10 });
            _sizeRestrictions.Add("HangarWidth", new double[2] { 2, 14 });
            _sizeRestrictions.Add("HangarLength", new double[2] { 2, 40 });
            _sizeRestrictions.Add("GateHeight", new double[2] { 2, 10 });
            _sizeRestrictions.Add("GateWidth", new double[2] { 0.25, 7 });
            _sizeRestrictions.Add("WallHeight", new double[2] { 0.1, 0.3 });
            _nameRestrictions.Add("HangarHeight", "Высота ангара");
            _nameRestrictions.Add("HangarWidth", "Ширина ангара");
            _nameRestrictions.Add("HangarLength", "Длина ангара");
            _nameRestrictions.Add("GateHeight", "Высота ворот");
            _nameRestrictions.Add("GateWidth", "Ширина ворот");
            _nameRestrictions.Add("WallHeight", "Высота стены");
        }

        /// <summary>
        /// Возвращает и задаёт снеговую нагрузку.
        /// </summary>
        public int SnowLoad
        {
            get
            {
                return _seasonalSnowLoads;
            }
            set
            {
                _seasonalSnowLoads = value;
            }
        }
        /// <summary>
        /// Возвращает и задаёт длину свай.
        /// </summary>
        public double HeightPiles
        {
            get
            {
                return _heightPiles;
            }
            private set
            {
                _heightPiles = value;
            }
        }
        /// <summary>
        /// Возвращает и задаёт число свай.
        /// </summary>
        public int QuantityPiles
        {
            get
            {
                return _quantityPiles;
            }
            private set
            {
                _quantityPiles = value;
            }
        }
        /// <summary>
        /// Возвращает и задаёт высоту ангара с ограничением 2..10 метров.
        /// </summary>
        public double HangarHeight
        {
            get
            {
                return _hangarHeight;
            }
            set
            {
                LimitCheck("HangarHeight", value);
                _hangarHeight = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт ширину ангара с ограничением 2..14 метров.
        /// </summary>
        public double HangarWidth
        {
            get
            {
                return _hangarWidth;
            }
            set
            {
                LimitCheck("HangarWidth", value);
                _hangarWidth = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт длину ангара с ограничением 2..40 метров.
        /// </summary>
        public double HangarLength
        {
            get
            {
                return _hangarLength;
            }
            set
            {
                LimitCheck("HangarLength", value);
                _hangarLength = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт высоту ворот с ограничением 2..(высота ангара) метров.
        /// </summary>
        public double GateHeight
        {
            get
            {
                return _gateHeight;
            }
            set
            {
                if (HangarHeight != 0)
                    _sizeRestrictions["GateHeight"][1] = HangarHeight;
                LimitCheck("GateHeight", value);
                _gateHeight = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт ширину ворот с ограничением (Ширина ангара 25%) ..(Ширина ангара 50%) метров.
        /// </summary>
        public double GateWidth
        {
            get
            {
                return _gateWidth;
            }
            set
            {
                if (HangarWidth != 0)
                {
                    _sizeRestrictions["GateWidth"][0] = HangarWidth / 4;
                    _sizeRestrictions["GateWidth"][1] = HangarWidth / 2;
                }
                LimitCheck("GateWidth", value);
                _gateWidth = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт высоту стен (подошвы) с ограничением 0.1..0.3 метров.
        /// </summary>
        public double WallHeight
        {
            get
            {
                return _wallHeight;
            }
            set
            {
                LimitCheck("WallHeight", value);
                _wallHeight = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт первый слой грунта.
        /// </summary>
        public Soil FirstSoil
        {
            get
            {
                return _firstSoil;
            }
            set
            {
                _firstSoil = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт второй слой грунта.
        /// </summary>
        public Soil SecondSoil
        {
            get
            {
                return _secondSoil;
            }
            set
            {
                _secondSoil = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт третий слой грунта.
        /// </summary>
        public Soil ThirdSoil
        {
            get
            {
                return _thirdSoil;
            }
            set
            {
                _thirdSoil = value;
            }
        }

        /// <summary>
        /// Метод, проверяющий пар-ры на ограничения с помощью словаря.
        /// В случае выхода за границы, генерирует исключение.
        /// </summary>
        /// <param name="key">Ключ по которому из словаря определяются мин и макс значения.</param>
        /// <param name="value">Значение переменной для сравнения с ограничителями.</param>
        private void LimitCheck(string key, double value)
        {
            double min = _sizeRestrictions[key][0];
            double max =_sizeRestrictions[key][1];
            string nameParam = _nameRestrictions[key];
            if ( value < min || value > max)
                throw new ArgumentException(nameParam + " не может быть меньше " + min + "м или больше " + max + "м.");
        }

        /// <summary>
        /// Метод производит расчёт веса ангара, сравнивая его с нагрузкой грунта.
        /// Если грунт не способен выдержать, тогда происходит перерасчёт параметров с учётом второго грунта, далее с третьим. Если здание слишком тяжело, тогда
        /// генерируется исключение.
        /// Если грунт подходящий, происходит подсчёт длины свай.
        /// </summary>
        public void CheckCompatibility()
        {
            double depthFactor = 1.4;
            int areaPile = 625;
            double specificLoadOfFirstSoil = FirstSoil.Load * depthFactor * FirstSoil.Size;
            double specificLoadOfSecondSoil = SecondSoil.Load * depthFactor * SecondSoil.Size;
            double specificLoadOfThirdSoil = ThirdSoil.Load * depthFactor * ThirdSoil.Size;
            QuantityPiles = (1 + (int)HangarLength / 2) * 2;
            double roofArea = HangarLength * HangarWidth;
            double wallArea = (HangarHeight * HangarWidth + HangarHeight * HangarLength) * 2;
            double wallPerimeter = (HangarLength + HangarWidth) * 2;
            double pileDepth = roofArea * _seasonalSnowLoads + roofArea * _specificGravityOfProfiledSheet + wallArea * _specificGravityOfSteelSheet + _specificGravityOfReinforcedConcrete * wallPerimeter * 0.2 * WallHeight;
            if (pileDepth * _safetyFactor / (areaPile * specificLoadOfFirstSoil) > QuantityPiles)
                if (pileDepth * _safetyFactor / (areaPile * (specificLoadOfSecondSoil + specificLoadOfFirstSoil)) > QuantityPiles)
                    if (pileDepth * _safetyFactor / (areaPile * (specificLoadOfSecondSoil + specificLoadOfFirstSoil + specificLoadOfThirdSoil)) > QuantityPiles)
                    {
                        HeightPiles = 0;
                        throw new System.Exception("Ни один из слоёв грунта не способен выдержать ангар с весом = " + pileDepth + " кг.");
                    }
                    else
                        HeightPiles = FirstSoil.Size + SecondSoil.Size + (pileDepth * _safetyFactor / (areaPile * QuantityPiles) - specificLoadOfFirstSoil - specificLoadOfSecondSoil) / ThirdSoil.Load * depthFactor;
                else
                    HeightPiles = FirstSoil.Size + (pileDepth * _safetyFactor / (areaPile * QuantityPiles) - specificLoadOfFirstSoil) / SecondSoil.Load * depthFactor;
            else
                HeightPiles = pileDepth * _safetyFactor / (areaPile * QuantityPiles * FirstSoil.Load * depthFactor);
        }

    }
}
