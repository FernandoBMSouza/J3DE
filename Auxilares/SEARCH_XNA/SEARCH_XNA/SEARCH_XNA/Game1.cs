using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SEARCH_XNA
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;

        int[] values;
        int[] sortedValues;
        const int MAX = 10;
        Random random;
        bool sort;

        //SEARCH
        int target;
        bool search;
        string m1, m2;
        Color color, color2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "SEARCH";
        }

        protected override void Initialize()
        {
            Create();

            base.Initialize();
        }

        private void Create()
        {
            sort = false;
            random = new Random();
            values = new int[MAX];
            sortedValues = new int[MAX];

            for (int i = 0; i < MAX; i++)
            {
                int r = random.Next(100);
                values[i] = sortedValues[i] = r;
            }

            target = random.Next(100);
            search = false;
            m1 = m2 = "";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>(@"Fonts\Arial");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) Create();

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !sort)
            {
                sort = true;
                BubbleSort();
                //MergeSort(0, sortedValues.Length, sortedValues);
                //QuickSort(sortedValues, 0, sortedValues.Length - 1);
                //HeapSort(sortedValues.Length, sortedValues);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && sort && !search)
            {
                search = true;
                SearchD();
                Search();
            }

            base.Update(gameTime);
        }

        private void SearchD()
        {
            bool aux = false;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == target)
                {
                    aux = true;
                    m1 = "Valor " + target + " foi encontrado no indice " + i + "!";
                    color = Color.Blue;
                    return;
                }
            }

            if (!aux)
            {
                m1 = "Valor " + target + " inexistente!";
                color = Color.Red;
            }
        }

        private void Search()
        {
            bool aux = false;

            for (int i = 0; i < sortedValues.Length; i++)
            {
                if (sortedValues[i] == target)
                {
                    aux = true;
                    m2 = "Valor " + target + " foi encontrado no indice " + i + "!";
                    color2 = Color.DarkBlue;
                    break;
                }
                else if (sortedValues[i] > target)
                {
                    aux = true;
                    m2 = "Valor " + target + " inexistente ate o indice " + i + "!";
                    color2 = Color.DarkRed;
                    break;
                }
            }

            if (!aux)
            {
                m2 = "Valor " + target + " inexistente!";
                color2 = Color.DarkRed;
            }
        }

        // BUBBLE SORT

        private void BubbleSort()
        {
            for (int i = 0; i < sortedValues.Length - 1; i++)
            {
                for (int j = i + 1; j < sortedValues.Length; j++)
                {
                    if (sortedValues[i] > sortedValues[j])
                    {
                        int temp = sortedValues[i];
                        sortedValues[i] = sortedValues[j];
                        sortedValues[j] = temp;
                    }
                }
            }
        }

        // QUICK SORT

        void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }

        int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }
            }

            array[right] = array[i];
            array[i] = pivot;
            return i;
        }

        // MERGE SORT

        void MergeSort(int p, int r, int[] array)
        {
            if (p < r - 1)
            {
                int q = (p + r) / 2;
                MergeSort(p, q, array);
                MergeSort(q, r, array);
                Merge(p, q, r, array);
            }
        }

        void Merge(int p, int q, int r, int[] array)
        {
            int i = p;
            int j = q;
            int k = 0;
            int[] w = new int[r - p];

            while (i < q && j < r)
            {
                if (array[i] <= array[j])
                {
                    w[k++] = array[i++];
                }
                else
                {
                    w[k++] = array[j++];
                }
            }

            while (i < q)
            {
                w[k++] = array[i++];
            }

            while (j < r)
            {
                w[k++] = array[j++];
            }

            for (i = p; i < r; i++)
                array[i] = w[i - p];
        }

        // HEAP SORT

        void InsertHeap(int m, int[] array)
        {
            int f = m;

            while (f > 0 && array[(f - 1) / 2] < array[f])
            {
                int t = array[(f - 1) / 2];
                array[(f - 1) / 2] = array[f];
                array[f] = t;
                f = (f - 1) / 2;
            }
        }

        void ShakeHeap(int m, int[] array)
        {
            int f = 0;

            while (2 * f + 1 <= m)
            {
                int largest = 2 * f + 1;
                if (largest + 1 <= m && array[largest] < array[largest + 1])
                    largest++;

                if (array[f] >= array[largest])
                    break;

                int t = array[f];
                array[f] = array[largest];
                array[largest] = t;
                f = largest;
            }
        }

        void HeapSort(int n, int[] array)
        {
            // Build the heap
            for (int i = 1; i < n; i++)
                InsertHeap(i, array);

            // Extract elements from the heap
            for (int i = n - 1; i >= 1; i--)
            {
                int t = array[0];
                array[0] = array[i];
                array[i] = t;
                ShakeHeap(i - 1, array);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //TARGET
            spriteBatch.DrawString(font,
                                       "TARGET: " + target,
                                       new Vector2(60, 50),
                                       Color.Blue);
            //SORT
            for (int i = 0; i < MAX; i++)
            {
                spriteBatch.DrawString(font,
                                       values[i].ToString(),
                                       new Vector2((i + 1) * 60, 100),
                                       Color.Black);
                if (sort)
                    spriteBatch.DrawString(font,
                                           sortedValues[i].ToString(),
                                           new Vector2((i + 1) * 60, 200),
                                           Color.Black);
            }

            //SEARCH D (Desordenado)
            spriteBatch.DrawString(font,
                                   m1,
                                   new Vector2(70, 150),
                                   color);

            //SEARCH (Ordenado)
            spriteBatch.DrawString(font,
                                   m2,
                                   new Vector2(70, 250),
                                   color2);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
