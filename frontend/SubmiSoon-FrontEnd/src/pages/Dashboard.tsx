import { Navigate, useNavigate } from "react-router-dom";
import Assessment from "./Assessment";


const Dashboard = () => {
    const navigate = useNavigate();
    const data = [
    { name: "Budi Sulaiman", done: 10, total: 20 },
    { name: "Kezia Santoso", done: 6, total: 20 },
    { name: "Anto Susanto", done: 5, total: 20 },
    { name: "Kenny Vi", done: 5, total: 20 },
    { name: "Nunita", done: 5, total: 20 }
  ];

  return (
      <div className="w-full text-sm">
        <h1 className="mb-4 text-xl">Dashboard</h1>
        <h1 className="mb-4 text-lg font-bold">Leaderboard</h1>

        <table className="w-full border-collapse border border-gray-300">
          <thead>
            <tr className="bg-gray-100">
              <th className="border border-gray-300 py-2 px-4 text-left">Name</th>
              <th className="border border-gray-300 py-2 px-4 text-left">Total Assessment Done</th>
            </tr>
          </thead>

          {/* Rows */}
          <tbody>
            {data.map((item, idx) => (
              <tr key={idx}>
                <td className="border border-gray-300 py-3 px-4">{item.name}</td>
                <td className="border border-gray-300 py-3 px-4">
                  {item.done} / {item.total}
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        {/* Button */}
        <div className="mt-6 flex justify-start">
          <button onClick={() => navigate("/Assessment")} className="bg-[#FD9F4D] text-white px-4 py-2 rounded-lg text-sm cursor-pointer">
            View My Assessment
          </button>
        </div>
      </div>
    
    );
}

export default Dashboard