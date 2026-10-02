using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    // La classe Wind représente une zone dans laquelle le vent souffle dans une certaine direction avec une certaine force
    // La zone est définie par une position, une largeur et une hauteur
    // Un objet de type Wind est immuable, c'est-à-dire qu'on ne peut en changer aucune de ses caractéristiques
    // une fois qu'il a été créé.

    public class Wind
    {
        // TODO 01: Au moyen d'une enum publique, définir 'Directions', la liste des directions de vent possible (NORTH, EAST, WEST, SOUTH)

        // TODO 02: Déclarer les propriétés qui caractérisent le vent:
        //          - Sa direction (de type 'Directions')
        //          - Sa force
        //          - La zone (peut être plusieurs propriétés

        // TODO 03: Déclarer un constructeur dans lequel on met la direction à NORTH, la force à 10,
        //          la zone est à la position (50,50), fait 500 de large et 500 de haut

        // TODO 08: Modifier le constructeur pour qu'il soit défini au hasard:
        //          - Une direction aléatoire
        //          - Force entre 5 et 15
        //          - Position dans le quart en haut à gauche de l'espace aérien
        //          - Largeur et hauteur entre 200 et 500

    }
}
