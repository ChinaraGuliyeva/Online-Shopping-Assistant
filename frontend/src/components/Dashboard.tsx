import girl from "../assets/girl.jpg";
import { dashBoardHeading, dashBoardText } from "../textConstants";

export const Dashboard = () => {
	return (
		<>
			<div className="d-flex">
				<div className="col-md-6 description">
					<h1 className="mb-3 main-heading">{dashBoardHeading}</h1>
					{dashBoardText}
				</div>
				<div className="col-md-6 ms-5 mt-4">
					<img
						className="dashboard-img"
						src={girl}
						alt="female stylist in front of a board with sketches"
					/>
				</div>
			</div>
		</>
	);
};
