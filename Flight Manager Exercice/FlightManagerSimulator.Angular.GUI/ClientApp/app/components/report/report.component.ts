import { Component, OnInit } from '@angular/core';

import { ReportService } from '../../services/report.service';
import { Report } from '../../models/report/report.model';

@Component({
    selector: 'report',
    templateUrl: './report.component.html'
})
export class ReportComponent implements OnInit {

    public report: Report;

    constructor(private reportService :ReportService) {
        this.report = new Report();
    }


    ngOnInit() {
        this.reportService.getReport().subscribe(report =>
            this.report = report
        );
    }

}
