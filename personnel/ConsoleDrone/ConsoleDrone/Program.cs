using ConsoleApp1;
Console.CursorVisible = false;

List<Drone> dronesList = new List<Drone>(  );

dronesList.Add(new Drone(0, 0, 50, ConsoleColor.White));
dronesList.Add(new Drone(0, 10, 70, ConsoleColor.Red));
dronesList.Add(new Drone(0, 20, 50, ConsoleColor.Green));

while (DroneIsAlive(dronesList))
{
    Console.Clear();
    foreach (Drone drone in dronesList)
    {
        if (drone.battery > 0)
        {
            drone.StatusChange();
        }
        drone.ConsoleToShow();
    }
    Thread.Sleep(200);
}

Console.ReadKey();

bool DroneIsAlive(List<Drone> drones)
{
    foreach (Drone drone in drones)
    {
        if (drone.battery > 0) return true;
    }

    return false;
}
