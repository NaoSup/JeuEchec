﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Pawn : Pieces
    {
        //Constructeurs
        public Pawn(Colour colour, Coord coord) : base(colour, coord)
        {
            DisplayName = "Pa." + colour;
        }
        public Pawn(Colour colour) : base(colour)
        {
        }

        //Methode
        public override List<Coord> GetPossibleMoves(Pieces[,] GameBoard, Coord coord)
        {
            List<Coord> coords = new List<Coord>();
            Colour ColourEnnemy;
            int Direction;

            //direction des pions
            if (colour == Colour.black)
            {
                ColourEnnemy = Colour.white;
                Direction = 1;
            }

            else
            {
                ColourEnnemy = Colour.black;
                Direction = -1;
            }

            //initialisation 
            Pieces CaseDirection = null;
            Pieces CaseDirection2 = null;
            Pieces CaseSide1 = null;
            Pieces CaseSide2 = null;

            //Vérification coords dans les limites du plateau
            if (coord.x + Direction < 8)
                CaseDirection = GameBoard[coord.x + Direction, coord.y];

            if (coord.x + Direction < 8 && coord.y + 1 < 8)
                CaseSide1 = GameBoard[coord.x + Direction, coord.y + 1];

            if (coord.x + Direction < 8 && coord.y - 1 >= 0)
                CaseSide2 = GameBoard[coord.x + Direction, coord.y - 1];

            //Ajout des coords disponibles
            if (CaseDirection == null)//case en avant
                coords.Add(new Coord(coord.x + Direction, coord.y));

            if (CaseDirection == null && CaseDirection2 == null && (coord.x == 1 || coord.x == 6)) //2 cases en avant au premier tour
                coords.Add(new Coord(coord.x + (Direction*2), coord.y));

            if (CaseSide1 != null && CaseSide1.colour == ColourEnnemy) //Attaque Diagonale
                coords.Add(new Coord(coord.x + Direction, coord.y + 1));

            if (CaseSide2 != null && CaseSide2.colour == ColourEnnemy) //Attaque Diagonale
                coords.Add(new Coord(coord.x + Direction, coord.y - 1));

            return coords;
        }

    }
}
