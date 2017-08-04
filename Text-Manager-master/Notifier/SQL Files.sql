SELECT DISTINCT C.contactName, C.`contactNumber`, S.`SendingDateTime`, S.`TextDecoded`
FROM sentitems S
LEFT JOIN contacts C ON RIGHT(C.contactNumber,9) = RIGHT(S.DestinationNumber,9)
WHERE
 S.Status = 'SendingOKNoReport' AND
 S.`SendingDateTime` BETWEEN '2015-08-01 00:00:00' AND '2015-08-31 23:59:59'

mySql = "SELECT DISTINCT C.contactName, C.`contactNumber`, S.`SendingDateTime`, S.`TextDecoded` "
mySql &= vbCrLf & "FROM sentitems S "
mySql &= vbCrLf & "LEFT JOIN contacts C ON RIGHT(C.contactNumber,9) = RIGHT(S.DestinationNumber,9) "
mySql &= vbCrLf & "WHERE "
mySql &= vbCrLf & "S.Status = 'SendingOKNoReport' AND "
mySql &= vbCrLf & "S.`SendingDateTime` BETWEEN '2015-08-01 00:00:00' AND '2015-08-31 23:59:59'"