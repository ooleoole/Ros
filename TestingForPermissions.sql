SELECT c.Id,C.[Name],RaceEvents.Id,RaceEvents.[Name],u.Id,u.FirstName,ur.[Type] FROM RaceEvents
INNER JOIN Regattas AS Re
ON Re.Id=RaceEvents.Id
INNER JOIN Clubs AS C
ON C.Id=Re.ClubId
INNER JOIN Clubs_Users_UserRoles_Junctions AS Curj
ON Curj.ClubId=C.Id
INNER JOIN Users AS u
on u.Id=Curj.UserId
INNER JOIN UserRoles AS ur
ON ur.Id=Curj.Id

SELECT c.[Name],c.Id,us.FirstName,us.Id,ur.[Type] FROM Clubs AS c
INNER JOIN Clubs_Users_UserRoles_Junctions AS Curj
ON c.Id=Curj.Id
INNER Join UserRoles AS ur
ON Curj.UserRoleId=ur.id
INNER JOIN Users AS us
ON us.Id=Curj.UserId


SELECT so.Id,so.[Name],u.Id,u.FirstName,resu.Id,resu.FirstName FROM SocialEvents AS so
INNER JOIN Regattas AS r
ON so.RegattaId=r.Id
INNER JOIN Regattas_Entries AS re
ON re.RegattaId=r.Id
INNER JOIN Entries AS e
ON e.Id=re.EntryId
INNER JOIN RegisteredUsers AS ru
ON ru.EntryId=re.Id
INNER JOIN Users AS u
ON u.Id=ru.UserId
INNER JOIN Users AS resu
ON e.ResponsibleUserId=resu.Id