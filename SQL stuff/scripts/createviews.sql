CREATE VIEW dayview AS
SELECT 
	a.id, startDate, endDate, a.label, a.treatmentId, a.occured,
	colorR, colorG, colorB, firstname, lastname

FROM appointment AS a
	LEFT JOIN treatment AS t ON t.id = a.treatmentid 
	LEFT JOIN healer AS h ON t.healerid = h.id
	LEFT JOIN patient AS p ON t.patientid = p.id
;

