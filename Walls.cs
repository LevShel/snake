using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
    {
    class Walls
        {
        List<Figure> wallList;

        public Walls (int mapWidth, int mapHeight)
            {
            wallList = new List<Figure>();

            HorLine upLine = new HorLine(2, mapWidth-2, 2, '-');
            upLine.Draw();
            HorLine downLine = new HorLine(2, mapWidth-2, mapHeight-2, '-');
            downLine.Draw();
            VertLine leftLine = new VertLine(2, 2, mapHeight-2, '|');
            leftLine.Draw();
            VertLine rightLine = new VertLine(mapWidth - 2, 2, mapHeight -2, '|');
            rightLine.Draw();

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
            }

        internal bool IsHit(Figure figure)
            {
            foreach(var wall in wallList)
                {
                if(wall.IsHit(figure))
                    {
                    return true;
                    }
                }
            return false;
            }

        public void Draw()
            {
            foreach(var wall in wallList)
                {
                wall.Draw();
                }
            }
        }
    }
