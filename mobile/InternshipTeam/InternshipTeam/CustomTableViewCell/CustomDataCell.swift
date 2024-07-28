//
//  CustomDataCell.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 29.06.2024.
//

import UIKit

class CustomDataCell: UITableViewCell {
    
    static let identifier = "customDataCell"
    
    @IBOutlet weak var tradePointLabel: UILabel!
    @IBOutlet weak var comeDateLabel: UILabel!
    @IBOutlet weak var leaveDateLabel: UILabel!
    
    public func configure(_ data: EmployeeDatum, Dates: String...) {
        
        self.tradePointLabel.text = data.tradePoint.pointName
        comeDateLabel.text = Dates[0]
        leaveDateLabel.text = Dates[1]
    }
    
    public static func getNib() -> UINib {
        UINib(nibName: "CustomDataCell", bundle: nil)
    }

    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }
    
}
