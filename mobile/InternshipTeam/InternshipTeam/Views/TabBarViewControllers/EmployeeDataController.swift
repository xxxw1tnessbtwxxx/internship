//
//  EmployeeDataController.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 28.06.2024.
//

import UIKit

class EmployeeDataController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    
    var data: EmployeeData = []
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        print(data.count)
        return data.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        
        let item = data[indexPath.row]
        let cell = tableView.dequeueReusableCell(withIdentifier: CustomDataCell.identifier, for: indexPath) as! CustomDataCell
        
        cell.configure(item, Dates: DateTimeParser.GetDate(item.comeDate)!, DateTimeParser.GetDate(item.leaveDate)!)
        return cell
        
    }
    
    

    @IBOutlet weak var shiftTable: UITableView!
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        self.shiftTable.register(CustomDataCell.getNib(), forCellReuseIdentifier: "customDataCell")
        self.shiftTable.delegate = self
        self.shiftTable.dataSource = self
        
    }
    
    
    override func viewDidAppear(_ animated: Bool) {
        self.data.removeAll()
        
        var times: [WorkTime] = []
        APIManager.getEmployeeData { data in
            data.forEach { employeeData in
                self.data.append(employeeData)
                print(employeeData.comeDate)
                var work = WorkTime(comeDate: employeeData.comeDate, leaveDate: employeeData.comeDate)
                times.append(work)
            }
            DispatchQueue.main.async {
                self.shiftTable.reloadData()
            }
        }
        
        
    }
    
    
}
