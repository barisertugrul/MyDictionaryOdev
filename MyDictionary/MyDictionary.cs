using System;
using System.Collections.Generic;
using System.Text;

namespace MyDictionaryOdev
{
    class MyDictionary<TKey, TValue>
    {
        TKey[] _keys;
        TValue[] _values;


        public MyDictionary()
        {
            _keys = new TKey[0];
            _values = new TValue[0];
        }

        public TValue this[TKey key]
        {
            get
            {
                //key anahtarının index numarası çağrılıyor
                int index = IndexOf(key);

                //index -1'den büyükse key karşılığı var demektir'
                return index > -1 ? _values[index] : default(TValue);
                /* Önemli:
                 * default(TValue) kullanımı int için riskli
                 * Çünkü int için default değer 0,
                 * int listeler için 0 bir anlam ifade edebilir.
                 * Örneğin 0 değeri içeren elemanlar olabilir.
                 * Bu durumda dönen değerin gerçekten key karşılığı olup olmadığı anlaşılamaz.
                 * Bu soruna çözüm bulunmalı
                 */
            }
            set
            {
                //Console.WriteLine("Gönderilen KEY: " + key);
                //Console.WriteLine("Gönderilen VALUE: " + value);

                //Eğer key değeri listede varsa, bu değer çifti güncellenecek
                //Yoksa yeni değer çifti eklenecek
                if (ContainsKey(key))
                {
                    Update(key, value);
                }
                else
                {
                    Add(key, value);
                }
                    
            }
        }


        public DictionaryResult Add(TKey key, TValue value)
        {
            //Geri dönüş değişkeni tanımlanıyor
            DictionaryResult dictionaryResult = new DictionaryResult();
            
            //Önce dictionary için iletilen key değerinin
            //daha önce kaydedilip kaydedilmediği kontrol ediliyor

            if (ContainsKey(key))
            {
                //İletilen key değeri listede varsa ekleme işlemi iptal ediliyor
                dictionaryResult.Status = false;
                dictionaryResult.Message = "Gönderilen key değeri zaten kayıtlı. Tekrar aynı key değerini kullanamazsınız.";
                return dictionaryResult;
            }

            //Uygulama bu satıra ulaşmışsa key değeri daha önce kayıt edilmemiş demektir
            //Bu durumda kayıt işlemine devam edilir
            //key kaydı
            TKey[] tempKeyArray = _keys;
            _keys = new TKey[_keys.Length + 1];
            for (int i = 0; i < tempKeyArray.Length; i++)
            {
                _keys[i] = tempKeyArray[i];
            }
            _keys[_keys.Length - 1] = key;

            //value kaydı
            TValue[] tempValueArray = _values;
            _values = new TValue[_values.Length + 1];
            for (int i = 0; i < tempValueArray.Length; i++)
            {
                _values[i] = tempValueArray[i];
            }
            _values[_values.Length - 1] = value;
            dictionaryResult.Status = true;
            dictionaryResult.Data = _keys.Length - 1; //Yeni kaydın index değeri
            dictionaryResult.Message = "Yeni kayıt başarıyla eklendi";
            return dictionaryResult;
        }

        protected bool Update(TKey key, TValue value)
        {
            int index = IndexOf(key);
            if(index>-1)
            {
                _values[index] = value;
                return true;
            }
            return false;
        }

        public void Remove(TKey key)
        {
            int index = IndexOf(key);
            if (index > -1)
            {
                TKey[] tempKeyArray = _keys;
                TValue[] tempValueArray = _values;
                _keys = new TKey[_keys.Length - 1];
                _values = new TValue[_values.Length - 1];

                for (int i = index; i < _keys.Length; i++)
                {
                    _keys[i] = tempKeyArray[i + 1];
                    _values[i] = tempValueArray[i + 1];
                }
            }
        }

        public int Length
        {
            get { return _keys.Length; }
        }

        public TKey[] Keys
        {
            get { return _keys; }
        }

        public TValue[] Values
        {
            get { return _values; }
        }

        public bool ContainsKey(TKey key)
        {
            foreach (TKey vKey in _keys)
            {
                if (vKey.Equals(key))
                {
                    //İletilen key değeri listede varsa true döndürülür
                    return true;
                }
            }
            return false;
        }

        public bool ContainsValue(TValue value)
        {
            foreach (TValue vValue in _values)
            {
                if (vValue.Equals(value))
                {
                    //İletilen value değeri listede varsa true döndürülür
                    return true;
                }
            }
            return false;
        }

        protected int IndexOf(TKey key)
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                if (_keys[i].Equals(key))
                {
                    //İletilen key değeri listede varsa true döndürülür
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            _keys = new TKey[0];
            _values = new TValue[0];
        }
    }
}
