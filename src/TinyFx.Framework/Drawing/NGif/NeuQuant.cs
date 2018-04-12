using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Drawing.NGif
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant”的 XML 注释
    public class NeuQuant
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.netsize”的 XML 注释
        protected static readonly int netsize = 256; /* number of colours used */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.netsize”的 XML 注释
                                                     /* four primes near 500 - assume no image has a length so large */
                                                     /* that it is divisible by all four primes */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.prime1”的 XML 注释
        protected static readonly int prime1 = 499;
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.prime1”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.prime2”的 XML 注释
        protected static readonly int prime2 = 491;
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.prime2”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.prime3”的 XML 注释
        protected static readonly int prime3 = 487;
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.prime3”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.prime4”的 XML 注释
        protected static readonly int prime4 = 503;
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.prime4”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.minpicturebytes”的 XML 注释
        protected static readonly int minpicturebytes = (3 * prime4);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.minpicturebytes”的 XML 注释
        /* minimum size for input image */
        /* Program Skeleton
		   ----------------
		   [select samplefac in range 1..30]
		   [read image from input file]
		   pic = (unsigned char*) malloc(3*width*height);
		   initnet(pic,3*width*height,samplefac);
		   learn();
		   unbiasnet();
		   [write output image header, using writecolourmap(f)]
		   inxbuild();
		   write output image using inxsearch(b,g,r)      */

        /* Network Definitions
		   ------------------- */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.maxnetpos”的 XML 注释
        protected static readonly int maxnetpos = (netsize - 1);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.maxnetpos”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.netbiasshift”的 XML 注释
        protected static readonly int netbiasshift = 4; /* bias for colour values */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.netbiasshift”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.ncycles”的 XML 注释
        protected static readonly int ncycles = 100; /* no. of learning cycles */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.ncycles”的 XML 注释

        /* defs for freq and bias */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.intbiasshift”的 XML 注释
        protected static readonly int intbiasshift = 16; /* bias for fractions */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.intbiasshift”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.intbias”的 XML 注释
        protected static readonly int intbias = (((int)1) << intbiasshift);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.intbias”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.gammashift”的 XML 注释
        protected static readonly int gammashift = 10; /* gamma = 1024 */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.gammashift”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.gamma”的 XML 注释
        protected static readonly int gamma = (((int)1) << gammashift);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.gamma”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.betashift”的 XML 注释
        protected static readonly int betashift = 10;
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.betashift”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.beta”的 XML 注释
        protected static readonly int beta = (intbias >> betashift); /* beta = 1/1024 */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.beta”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.betagamma”的 XML 注释
        protected static readonly int betagamma =
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.betagamma”的 XML 注释
            (intbias << (gammashift - betashift));

        /* defs for decreasing radius factor */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.initrad”的 XML 注释
        protected static readonly int initrad = (netsize >> 3); /* for 256 cols, radius starts */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.initrad”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.radiusbiasshift”的 XML 注释
        protected static readonly int radiusbiasshift = 6; /* at 32.0 biased by 6 bits */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.radiusbiasshift”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.radiusbias”的 XML 注释
        protected static readonly int radiusbias = (((int)1) << radiusbiasshift);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.radiusbias”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.initradius”的 XML 注释
        protected static readonly int initradius = (initrad * radiusbias); /* and decreases by a */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.initradius”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.radiusdec”的 XML 注释
        protected static readonly int radiusdec = 30; /* factor of 1/30 each cycle */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.radiusdec”的 XML 注释

        /* defs for decreasing alpha factor */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.alphabiasshift”的 XML 注释
        protected static readonly int alphabiasshift = 10; /* alpha starts at 1.0 */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.alphabiasshift”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.initalpha”的 XML 注释
        protected static readonly int initalpha = (((int)1) << alphabiasshift);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.initalpha”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.alphadec”的 XML 注释
        protected int alphadec; /* biased by 10 bits */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.alphadec”的 XML 注释

        /* radbias and alpharadbias used for radpower calculation */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.radbiasshift”的 XML 注释
        protected static readonly int radbiasshift = 8;
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.radbiasshift”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.radbias”的 XML 注释
        protected static readonly int radbias = (((int)1) << radbiasshift);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.radbias”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.alpharadbshift”的 XML 注释
        protected static readonly int alpharadbshift = (alphabiasshift + radbiasshift);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.alpharadbshift”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.alpharadbias”的 XML 注释
        protected static readonly int alpharadbias = (((int)1) << alpharadbshift);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.alpharadbias”的 XML 注释

        /* Types and Global Variables
		-------------------------- */

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.thepicture”的 XML 注释
        protected byte[] thepicture; /* the input image itself */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.thepicture”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.lengthcount”的 XML 注释
        protected int lengthcount; /* lengthcount = H*W*3 */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.lengthcount”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.samplefac”的 XML 注释
        protected int samplefac; /* sampling factor 1..30 */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.samplefac”的 XML 注释

        //   typedef int pixel[4];                /* BGRc */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.network”的 XML 注释
        protected int[][] network; /* the network itself - [netsize][4] */
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.network”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.netindex”的 XML 注释
        protected int[] netindex = new int[256];
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.netindex”的 XML 注释
        /* for network lookup - really 256 */

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.bias”的 XML 注释
        protected int[] bias = new int[netsize];
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.bias”的 XML 注释
        /* bias and freq arrays for learning */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.freq”的 XML 注释
        protected int[] freq = new int[netsize];
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.freq”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.radpower”的 XML 注释
        protected int[] radpower = new int[initrad];
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.radpower”的 XML 注释
        /* radpower for precomputation */

        /* Initialise network in range (0,0,0) to (255,255,255) and set parameters
		   ----------------------------------------------------------------------- */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.NeuQuant(byte[], int, int)”的 XML 注释
        public NeuQuant(byte[] thepic, int len, int sample)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.NeuQuant(byte[], int, int)”的 XML 注释
        {

            int i;
            int[] p;

            thepicture = thepic;
            lengthcount = len;
            samplefac = sample;

            network = new int[netsize][];
            for (i = 0; i < netsize; i++)
            {
                network[i] = new int[4];
                p = network[i];
                p[0] = p[1] = p[2] = (i << (netbiasshift + 8)) / netsize;
                freq[i] = intbias / netsize; /* 1/netsize */
                bias[i] = 0;
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.ColorMap()”的 XML 注释
        public byte[] ColorMap()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.ColorMap()”的 XML 注释
        {
            byte[] map = new byte[3 * netsize];
            int[] index = new int[netsize];
            for (int i = 0; i < netsize; i++)
                index[network[i][3]] = i;
            int k = 0;
            for (int i = 0; i < netsize; i++)
            {
                int j = index[i];
                map[k++] = (byte)(network[j][0]);
                map[k++] = (byte)(network[j][1]);
                map[k++] = (byte)(network[j][2]);
            }
            return map;
        }

        /* Insertion sort of network and building of netindex[0..255] (to do after unbias)
		   ------------------------------------------------------------------------------- */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.Inxbuild()”的 XML 注释
        public void Inxbuild()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.Inxbuild()”的 XML 注释
        {

            int i, j, smallpos, smallval;
            int[] p;
            int[] q;
            int previouscol, startpos;

            previouscol = 0;
            startpos = 0;
            for (i = 0; i < netsize; i++)
            {
                p = network[i];
                smallpos = i;
                smallval = p[1]; /* index on g */
                                 /* find smallest in i..netsize-1 */
                for (j = i + 1; j < netsize; j++)
                {
                    q = network[j];
                    if (q[1] < smallval)
                    { /* index on g */
                        smallpos = j;
                        smallval = q[1]; /* index on g */
                    }
                }
                q = network[smallpos];
                /* swap p (i) and q (smallpos) entries */
                if (i != smallpos)
                {
                    j = q[0];
                    q[0] = p[0];
                    p[0] = j;
                    j = q[1];
                    q[1] = p[1];
                    p[1] = j;
                    j = q[2];
                    q[2] = p[2];
                    p[2] = j;
                    j = q[3];
                    q[3] = p[3];
                    p[3] = j;
                }
                /* smallval entry is now in position i */
                if (smallval != previouscol)
                {
                    netindex[previouscol] = (startpos + i) >> 1;
                    for (j = previouscol + 1; j < smallval; j++)
                        netindex[j] = i;
                    previouscol = smallval;
                    startpos = i;
                }
            }
            netindex[previouscol] = (startpos + maxnetpos) >> 1;
            for (j = previouscol + 1; j < 256; j++)
                netindex[j] = maxnetpos; /* really 256 */
        }

        /* Main Learning Loop
		   ------------------ */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.Learn()”的 XML 注释
        public void Learn()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.Learn()”的 XML 注释
        {

            int i, j, b, g, r;
            int radius, rad, alpha, step, delta, samplepixels;
            byte[] p;
            int pix, lim;

            if (lengthcount < minpicturebytes)
                samplefac = 1;
            alphadec = 30 + ((samplefac - 1) / 3);
            p = thepicture;
            pix = 0;
            lim = lengthcount;
            samplepixels = lengthcount / (3 * samplefac);
            delta = samplepixels / ncycles;
            alpha = initalpha;
            radius = initradius;

            rad = radius >> radiusbiasshift;
            if (rad <= 1)
                rad = 0;
            for (i = 0; i < rad; i++)
                radpower[i] =
                    alpha * (((rad * rad - i * i) * radbias) / (rad * rad));

            //fprintf(stderr,"beginning 1D learning: initial radius=%d\n", rad);

            if (lengthcount < minpicturebytes)
                step = 3;
            else if ((lengthcount % prime1) != 0)
                step = 3 * prime1;
            else
            {
                if ((lengthcount % prime2) != 0)
                    step = 3 * prime2;
                else
                {
                    if ((lengthcount % prime3) != 0)
                        step = 3 * prime3;
                    else
                        step = 3 * prime4;
                }
            }

            i = 0;
            while (i < samplepixels)
            {
                b = (p[pix + 0] & 0xff) << netbiasshift;
                g = (p[pix + 1] & 0xff) << netbiasshift;
                r = (p[pix + 2] & 0xff) << netbiasshift;
                j = Contest(b, g, r);

                Altersingle(alpha, j, b, g, r);
                if (rad != 0)
                    Alterneigh(rad, j, b, g, r); /* alter neighbours */

                pix += step;
                if (pix >= lim)
                    pix -= lengthcount;

                i++;
                if (delta == 0)
                    delta = 1;
                if (i % delta == 0)
                {
                    alpha -= alpha / alphadec;
                    radius -= radius / radiusdec;
                    rad = radius >> radiusbiasshift;
                    if (rad <= 1)
                        rad = 0;
                    for (j = 0; j < rad; j++)
                        radpower[j] =
                            alpha * (((rad * rad - j * j) * radbias) / (rad * rad));
                }
            }
            //fprintf(stderr,"finished 1D learning: readonly alpha=%f !\n",((float)alpha)/initalpha);
        }

        /* Search for BGR values 0..255 (after net is unbiased) and return colour index
		   ---------------------------------------------------------------------------- */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.Map(int, int, int)”的 XML 注释
        public int Map(int b, int g, int r)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.Map(int, int, int)”的 XML 注释
        {

            int i, j, dist, a, bestd;
            int[] p;
            int best;

            bestd = 1000; /* biggest possible dist is 256*3 */
            best = -1;
            i = netindex[g]; /* index on g */
            j = i - 1; /* start at netindex[g] and work outwards */

            while ((i < netsize) || (j >= 0))
            {
                if (i < netsize)
                {
                    p = network[i];
                    dist = p[1] - g; /* inx key */
                    if (dist >= bestd)
                        i = netsize; /* stop iter */
                    else
                    {
                        i++;
                        if (dist < 0)
                            dist = -dist;
                        a = p[0] - b;
                        if (a < 0)
                            a = -a;
                        dist += a;
                        if (dist < bestd)
                        {
                            a = p[2] - r;
                            if (a < 0)
                                a = -a;
                            dist += a;
                            if (dist < bestd)
                            {
                                bestd = dist;
                                best = p[3];
                            }
                        }
                    }
                }
                if (j >= 0)
                {
                    p = network[j];
                    dist = g - p[1]; /* inx key - reverse dif */
                    if (dist >= bestd)
                        j = -1; /* stop iter */
                    else
                    {
                        j--;
                        if (dist < 0)
                            dist = -dist;
                        a = p[0] - b;
                        if (a < 0)
                            a = -a;
                        dist += a;
                        if (dist < bestd)
                        {
                            a = p[2] - r;
                            if (a < 0)
                                a = -a;
                            dist += a;
                            if (dist < bestd)
                            {
                                bestd = dist;
                                best = p[3];
                            }
                        }
                    }
                }
            }
            return (best);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.Process()”的 XML 注释
        public byte[] Process()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.Process()”的 XML 注释
        {
            Learn();
            Unbiasnet();
            Inxbuild();
            return ColorMap();
        }

        /* Unbias network to give byte values 0..255 and record position i to prepare for sort
		   ----------------------------------------------------------------------------------- */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.Unbiasnet()”的 XML 注释
        public void Unbiasnet()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.Unbiasnet()”的 XML 注释
        {

#pragma warning disable CS0168 // 声明了变量“j”，但从未使用过
            int i, j;
#pragma warning restore CS0168 // 声明了变量“j”，但从未使用过

            for (i = 0; i < netsize; i++)
            {
                network[i][0] >>= netbiasshift;
                network[i][1] >>= netbiasshift;
                network[i][2] >>= netbiasshift;
                network[i][3] = i; /* record colour no */
            }
        }

        /* Move adjacent neurons by precomputed alpha*(1-((i-j)^2/[r]^2)) in radpower[|i-j|]
		   --------------------------------------------------------------------------------- */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.Alterneigh(int, int, int, int, int)”的 XML 注释
        protected void Alterneigh(int rad, int i, int b, int g, int r)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.Alterneigh(int, int, int, int, int)”的 XML 注释
        {

            int j, k, lo, hi, a, m;
            int[] p;

            lo = i - rad;
            if (lo < -1)
                lo = -1;
            hi = i + rad;
            if (hi > netsize)
                hi = netsize;

            j = i + 1;
            k = i - 1;
            m = 1;
            while ((j < hi) || (k > lo))
            {
                a = radpower[m++];
                if (j < hi)
                {
                    p = network[j++];
                    try
                    {
                        p[0] -= (a * (p[0] - b)) / alpharadbias;
                        p[1] -= (a * (p[1] - g)) / alpharadbias;
                        p[2] -= (a * (p[2] - r)) / alpharadbias;
                    }
#pragma warning disable CS0168 // 声明了变量“e”，但从未使用过
                    catch (Exception e)
#pragma warning restore CS0168 // 声明了变量“e”，但从未使用过
                    {
                    } // prevents 1.3 miscompilation
                }
                if (k > lo)
                {
                    p = network[k--];
                    try
                    {
                        p[0] -= (a * (p[0] - b)) / alpharadbias;
                        p[1] -= (a * (p[1] - g)) / alpharadbias;
                        p[2] -= (a * (p[2] - r)) / alpharadbias;
                    }
#pragma warning disable CS0168 // 声明了变量“e”，但从未使用过
                    catch (Exception e)
#pragma warning restore CS0168 // 声明了变量“e”，但从未使用过
                    {
                    }
                }
            }
        }

        /* Move neuron i towards biased (b,g,r) by factor alpha
		   ---------------------------------------------------- */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.Altersingle(int, int, int, int, int)”的 XML 注释
        protected void Altersingle(int alpha, int i, int b, int g, int r)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.Altersingle(int, int, int, int, int)”的 XML 注释
        {

            /* alter hit neuron */
            int[] n = network[i];
            n[0] -= (alpha * (n[0] - b)) / initalpha;
            n[1] -= (alpha * (n[1] - g)) / initalpha;
            n[2] -= (alpha * (n[2] - r)) / initalpha;
        }

        /* Search for biased BGR values
		   ---------------------------- */
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NeuQuant.Contest(int, int, int)”的 XML 注释
        protected int Contest(int b, int g, int r)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NeuQuant.Contest(int, int, int)”的 XML 注释
        {

            /* finds closest neuron (min dist) and updates freq */
            /* finds best neuron (min dist-bias) and returns position */
            /* for frequently chosen neurons, freq[i] is high and bias[i] is negative */
            /* bias[i] = gamma*((1/netsize)-freq[i]) */

            int i, dist, a, biasdist, betafreq;
            int bestpos, bestbiaspos, bestd, bestbiasd;
            int[] n;

            bestd = ~(((int)1) << 31);
            bestbiasd = bestd;
            bestpos = -1;
            bestbiaspos = bestpos;

            for (i = 0; i < netsize; i++)
            {
                n = network[i];
                dist = n[0] - b;
                if (dist < 0)
                    dist = -dist;
                a = n[1] - g;
                if (a < 0)
                    a = -a;
                dist += a;
                a = n[2] - r;
                if (a < 0)
                    a = -a;
                dist += a;
                if (dist < bestd)
                {
                    bestd = dist;
                    bestpos = i;
                }
                biasdist = dist - ((bias[i]) >> (intbiasshift - netbiasshift));
                if (biasdist < bestbiasd)
                {
                    bestbiasd = biasdist;
                    bestbiaspos = i;
                }
                betafreq = (freq[i] >> betashift);
                freq[i] -= betafreq;
                bias[i] += (betafreq << gammashift);
            }
            freq[bestpos] += beta;
            bias[bestpos] -= betagamma;
            return (bestbiaspos);
        }
    }
}
