using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarAlgorithm
{
    public partial class Form1 : Form
    {
        Cell goal = new Cell();
        Cell start = new Cell();
        List<Cell> map;
        List<Cell> path;
        private bool shouldPlaceWall = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            dgvMap.RowCount = 21;
            dgvMap.ColumnCount = 27;
            map = new List<Cell>();

        }

        public void CoverOverPath(List<Cell> resultPath)
        {
            int x, y = 0;

            resultPath.Remove(resultPath.First());
            resultPath.Remove(resultPath.Last());

            foreach (var cell in resultPath)
            {
                x = cell.X;
                y = cell.Y;
                dgvMap.Rows[x].Cells[y].Value = "●";
            }

        }

        private void btnSetStart_Click(object sender, EventArgs e)
        {
            int colorChecker = 0;
            for (int i = 0; i < dgvMap.RowCount; i++)
            {
                for (int j = 0; j < dgvMap.ColumnCount; j++)
                {
                    if (dgvMap.Rows[i].Cells[j].Style.BackColor == Color.Green)
                    {
                        colorChecker += 1;
                    }
                }
            }
            if (colorChecker == 0)
            {
                dgvMap.CurrentCell.Style.BackColor = Color.Green;
                start = new Cell();
                start.X = dgvMap.CurrentCell.RowIndex;
                start.Y = dgvMap.CurrentCell.ColumnIndex;

            }
            else
                MessageBox.Show("The START point is already exist!");

        }

        private void btnSetFinish_Click(object sender, EventArgs e)
        {
            int colorChecker = 0;
            for (int i = 0; i < dgvMap.RowCount; i++)
            {
                for (int j = 0; j < dgvMap.ColumnCount; j++)
                {
                    if (dgvMap.Rows[i].Cells[j].Style.BackColor == Color.DarkBlue)
                    {
                        colorChecker += 1;
                    }
                }
            }
            if (colorChecker == 0)
            {
                dgvMap.CurrentCell.Style.BackColor = Color.DarkBlue;
                goal = new Cell();
                goal.X = dgvMap.CurrentCell.RowIndex;
                goal.Y = dgvMap.CurrentCell.ColumnIndex;
            }
            else
                MessageBox.Show("The START point is already exist!");

        }

        private void btnClearMap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMap.RowCount; i++)
            {
                for (int j = 0; j < dgvMap.ColumnCount; j++)
                {
                    dgvMap.Rows[i].Cells[j].Style.BackColor = Color.White;
                    dgvMap.Rows[i].Cells[j].Value = "";

                }
            }
        }

        private void btnSetWall_Click(object sender, EventArgs e)
        {
            //dgvMap.CurrentCell.Style.BackColor = Color.DarkRed;
            shouldPlaceWall = true;

        }



        private void btnPathFinding_Click(object sender, EventArgs e)
        {
            algorithm(start, goal);
            CoverOverPath(path);

        }



        public List<Cell> GetMap()
        {
            List<Cell> map = new List<Cell>();
            for (int i = 0; i < dgvMap.RowCount; i++)
            {
                for (int j = 0; j < dgvMap.ColumnCount; j++)
                {
                    Cell cell = new Cell();
                    cell.X = dgvMap.Rows[i].Cells[j].RowIndex;
                    cell.Y = dgvMap.Rows[i].Cells[j].ColumnIndex;


                    if (dgvMap.Rows[i].Cells[j].Style.BackColor == Color.DarkRed)
                    {
                        cell.gValue = 1999;
                    }

                    map.Add(cell);
                }
            }
            return map;
        }

        public List<Cell> algorithm(Cell start, Cell goal)
        {
            List<Cell> map = new List<Cell>();
            map = GetMap();

            Cell currentCell = new Cell();
            Cell openCell = new Cell();

            List<Cell> closedList = new List<Cell>();
            List<Cell> openList = new List<Cell>();


           
            start.CameFrom = null;
            start.gValue = 0;
            start.hValue = GetHeuristicValue(start, goal);


            openList.Add(start);
            while (openList.Count > 0)
            {

                currentCell = openList.OrderBy(cell => cell.fValue).First();

                if (currentCell.X == goal.X && currentCell.Y == goal.Y)
                {
                    return path = GetFullPath(currentCell);

                }

                openList.Remove(currentCell);
                closedList.Add(currentCell);

                foreach (var neighbourCell in GetNeighboursList(currentCell, map))
                {

                    if (closedList.Exists(cell => cell.X == neighbourCell.X && cell.Y == neighbourCell.Y))
                        continue;
                    openCell = openList.FirstOrDefault(cell => cell.X == neighbourCell.X && cell.Y == neighbourCell.Y);

                    if (openCell == null)
                    {
                        openList.Add(neighbourCell);
                    }
                    else
                        if (openCell.gValue < neighbourCell.gValue)
                        {

                            openCell.CameFrom = currentCell;
                            openCell.gValue = neighbourCell.gValue;
                        }
                }
            }

            return null;

        }
        public int GetHeuristicValue(Cell currentCell, Cell goal)
        {
            int heuristicValue = 0;
            if (currentCell.gValue == 1999)
            {
                return heuristicValue = 100;
            }
            else
                return heuristicValue = Math.Abs(currentCell.X - goal.X) + Math.Abs(currentCell.Y - goal.Y);
        }


        public double GetDistanceBetweenCells(Cell currentCell, Cell neighbour)
        {
            double distance = 0.0;
            double calculatedX = Math.Pow((currentCell.X - neighbour.X), 2);
            double calculatedY = Math.Pow((currentCell.Y - neighbour.Y), 2);
            return distance = Math.Sqrt(calculatedX + calculatedY);
        }

        public static List<Cell> GetFullPath(Cell goal)
        {
            List<Cell> fullPath = new List<Cell>();
            Cell currentCell = goal;
            while (currentCell != null)
            {
                fullPath.Add(currentCell);
                currentCell = currentCell.CameFrom;
            }
            fullPath.Reverse();
            return fullPath;
        }





        public List<Cell> GetNeighboursList(Cell currentCell, List<Cell> mapCells)
        {
            List<Cell> neighbours = new List<Cell>();
            List<Cell> resultNeighbours = new List<Cell>();
            Cell cell = new Cell();

            if (currentCell.NorthNeighbour == null) cell = currentCell.FindCell(currentCell.X, currentCell.Y + 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.SouthNeighbour == null) cell = currentCell.FindCell(currentCell.X, currentCell.Y - 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.WestNeighbour == null) cell = currentCell.FindCell(currentCell.X - 1, currentCell.Y, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.EastNeighbour == null) cell = currentCell.FindCell(currentCell.X + 1, currentCell.Y, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }

            if (currentCell.LeftLowerNeighbour == null) cell = currentCell.LeftLowerNeighbour = currentCell.FindCell(currentCell.X - 1, currentCell.Y - 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.LeftUpperNeighbour == null) cell = currentCell.LeftUpperNeighbour = currentCell.FindCell(currentCell.X - 1, currentCell.Y + 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.RightLowerNeighbour == null) cell = currentCell.RightLowerNeighbour = currentCell.FindCell(currentCell.X + 1, currentCell.Y - 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.RightUpperNeighbour == null) cell = currentCell.RightUpperNeighbour = currentCell.FindCell(currentCell.X + 1, currentCell.Y + 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }



            foreach (var neighbour in neighbours)
            {


                Cell neighbourNode = new Cell();

                neighbourNode.X = neighbour.X;
                neighbourNode.Y = neighbour.Y;
                neighbourNode.CameFrom = currentCell;
                neighbourNode.gValue = currentCell.gValue + GetDistanceBetweenCells(currentCell, neighbour);
                neighbourNode.hValue = GetHeuristicValue(neighbour, goal);

                resultNeighbours.Add(neighbourNode);
            }

            return resultNeighbours;
        }

        private void dgvMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (shouldPlaceWall)
                    dgvMap.CurrentCell.Style.BackColor = Color.DarkRed;

            }
            else
            {
                shouldPlaceWall = false;
            }
        }


    }
}

