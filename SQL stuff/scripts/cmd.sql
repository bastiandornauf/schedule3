select gi.label as Gruppe, sum(fee) as total, insurance.label as AArt from
groupitems as g join invoiceitem as i
on g.invoiceitemid = i.id
join invoicegroup as gi
on g.invoicegroupid = gi.id
join fee
on i.id = fee.invoiceitemid
join insurance
on fee.insuranceid = insurance.id
group by insurance.label, gi.label;