﻿namespace Data
    {
    public class LookupTable
        {
        #region private fields

        uint[] LUTdata1D = null;
        uint[,] LUTdata2D = null;

        #endregion private fields

        public uint[] LUTData1D
            {
            get
                {
                return LUTdata1D;
                }
            }

        public bool Load()
            {
            int width = 256;

            LUTdata1D = new uint[256];

            //for ( int i = 150; i < 160; ++i )
            //    LUTdata1D[i] = (uint) ( ( ( i-50 ) << 24 ) | ( ( i-0 ) << 16 ) );

            /*
                                Vh = k*H+q
                                Vl = k*L+q
                                -----------------
                                Vh-k*H = q
                                Vl = k*L+Vh-kH    =>     (Vl-Vh)=k*(L-H)   ==>   (Vl-Vh)/(L-H) = k
                                Vh-(Vl-Vh)/(L-H)*H = q

                    */

            for ( int i = 188; i < width-10; ++i )
                LUTdata1D[i] = (uint) ( ( ( i - 150 ) << 24 ) | ( ( i-50 ) << 08 ) | ( ( i-50 ) << 16 ) | ( ( i-60 ) << 0 ) );

            int L = 175;
            int H = 180;
            float Vl = 8;
            float Vh = 12;
            float k = ( Vl - Vh )/( L - H );
            float q = Vh-( Vl-Vh )/( L-H )*H;

            for ( int i = L; i < H; ++i )
                LUTdata1D[i] = (uint) ( ( ( (uint) ( System.Math.Round( i*k+q ) ) ) << 24 ) | ( (uint) ( System.Math.Round( i+70f ) ) << 0 ) );

            L = 185;
            H = 190;
            Vl = 120;
            Vh = 50;
            k = ( Vl - Vh )/( L - H );
            q = Vh-( Vl-Vh )/( L-H )*H;

            //for ( int i = L; i < H; ++i )
            //    LUTdata1D[i] = (uint) ( ( ( (uint) ( System.Math.Round( i*k+q ) ) ) << 24 ) | ( (uint) ( System.Math.Round( i+70f ) ) << 8 ) );

            return true;
            }
        }
    }