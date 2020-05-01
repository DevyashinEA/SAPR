using System;

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
        const double _safetyMargin = 1.2;
        /// <summary>
        /// Удельный вес профлиста крыши.
        /// </summary>
        const int _specificProfiledSheet = 50;
        /// <summary>
        /// Удельные вес стальных листов стен и ворот.
        /// </summary>
        const int _specificSteelSheet = 60;
        /// <summary>
        /// Удельный вес железобетонного фундамента и подстенки (подошвы).
        /// </summary>
        const int _specificReinforcedConcrete = 2500;
        /// <summary>
        /// Снеговая нагрузка.
        /// </summary>
        private int _snowLoad = 300;
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
        /// Возвращает и задаёт снеговую нагрузку.
        /// </summary>
        public int SnowLoad
        {
            get
            {
                return _snowLoad;
            }
            set
            {
                _snowLoad = value;
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
                if (value <= 10 && value >= 2)
                    _hangarHeight = value;
                else
                    throw new ArgumentException("Высота ангара не может быть меньше 2м или больше 10м.");
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
                if (value <= 14 && value >= 2)
                    _hangarWidth = value;
                else
                    throw new ArgumentException("Ширина ангара не может быть меньше 2м или больше 14м.");
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
                if (value <= 40 && value >= 2)
                    _hangarLength = value;
                else
                    throw new ArgumentException("Длина ангара не может быть меньше 2м или больше 40м.");
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
                if (value <= HangarHeight && value >= 2)
                    _gateHeight = value;
                else
                    throw new ArgumentException("Высота ворот не может быть меньше 2м или больше " + HangarHeight + "м.");
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
                if (value <= HangarWidth / 2 && value >= HangarWidth / 4)
                    _gateWidth = value;
                else
                    throw new ArgumentException("Ширина ворот не может быть меньше " + HangarWidth / 4 + "м или больше " + HangarWidth / 2 + "м.");
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
                if (value <= 0.3 && value >= 0.1)
                    _wallHeight = value;
                else
                    throw new ArgumentException("Высота стена не может быть меньше 0.1м или больше 0.3м.");
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
        /// Метод производит расчёт веса ангара, сравнивая его с нагрузкой грунта.
        /// Если грунт не способен выдержать, тогда происходит перерасчёт параметров с учётом второго грунта, далее с третьим. Если здание слишком тяжело, тогда
        /// генерируется исключение.
        /// Если грунт подходящий, происходит подсчёт длины свай.
        /// </summary>
        public void CheckCompatibility()
        {
            double firstLoad = FirstSoil.Load * 1.4 * FirstSoil.Size;
            double secondLoad = SecondSoil.Load * 1.4 * SecondSoil.Size;
            double thirdLoad = ThirdSoil.Load * 1.4 * ThirdSoil.Size;
            QuantityPiles = (1 + (int)HangarLength / 2) * 2;
            double areaRoof = HangarLength * HangarWidth;
            double areaWall = (HangarHeight * HangarWidth + HangarHeight * HangarLength) * 2;
            double perimeterWall = (HangarLength + HangarWidth) * 2;
            double weight = areaRoof * _snowLoad + areaRoof * _specificProfiledSheet + areaWall * _specificSteelSheet + _specificReinforcedConcrete * perimeterWall * 0.2 * WallHeight;
            if (weight * _safetyMargin / (625 * firstLoad) > QuantityPiles)
                if (weight * _safetyMargin / (625 * (secondLoad + firstLoad)) > QuantityPiles)
                    if (weight * _safetyMargin / (625 * (secondLoad + firstLoad + thirdLoad)) > QuantityPiles)
                    {
                        HeightPiles = 0;
                        throw new System.Exception("Ни один из слоёв грунта не способен выдержать ангар с весом = " + weight + " кг.");
                    }
                    else
                        HeightPiles = FirstSoil.Size + SecondSoil.Size + (weight * _safetyMargin / (625 * QuantityPiles) - firstLoad - secondLoad) / ThirdSoil.Load * 1.4;
                else
                    HeightPiles = FirstSoil.Size + (weight * _safetyMargin / (625 * QuantityPiles) - firstLoad) / SecondSoil.Load * 1.4;
            else
                HeightPiles = weight * _safetyMargin / (625 * QuantityPiles * FirstSoil.Load * 1.4);
        }

    }
}
