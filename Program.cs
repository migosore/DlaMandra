﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


// brać pod uwagę jakie czasteczka ma przyspieszenie i żeby UpdatePosition brało ją pod uwage wyliczając pozycję

// wyrzucić trajektorię w CSV i wrzucić do excela żeby był wykres, 200 pozycji
// replace kropka na przecinek

//wrzucić na githuba i posłać linka

namespace C_Sharp_First_Project
{
    class Particle
    {
        private Point _position;
        private Point _velocity;
        private Point _acceleration;

        public Particle(Point position, Point velocity, Point acceleration)
        {
            _position = position;
            _velocity = velocity;
            _acceleration = acceleration;

        }
        
        void UpdatePosition()
        {   
           _velocity.Add(_acceleration);
           _position.Add(_velocity);
        }

        
    }



    class Point
    {
        private double _x;
        private double _y;

        public void Add(Point velocity)
        {
            _x += velocity._x;
            _y += velocity._y;
        }

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public void ShowPosition(Point p)
        {
           Console.Write(Math.Round(p._x, 2));
            Console.Write("\t");
            Console.WriteLine(Math.Round(p._y, 2));
        }
       
        public override string ToString()
        {
            // "[12.3; 56.4]"

            // return "[" + _x + "; " + _y + "]"; <= chujowo
            return string.Format("[{0};{1}]", _x, _y); // <= ok

            // return "[$_x;$_y]" <= C# 6.0, zajebiscie!
        }
    }

    class Program
    {

        private static void Main(string[] args)
        {
            Point p1 = new Point(100, 100);
            Console.WriteLine("p1:{0}", p1);
            Point velocityofPoint = new Point(20, 5);
            Point accelerationofPoint = new Point(-0.5, -0.1);

            int i = 0;
            while (i < 200)
            {
                velocityofPoint.Add(accelerationofPoint);
                p1.Add(velocityofPoint);
                
                p1.ShowPosition(p1);
                i++;
              }
        }
    }
    
}
