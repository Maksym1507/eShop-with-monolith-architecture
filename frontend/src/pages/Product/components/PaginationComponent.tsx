import React from "react";

type Props = {
  totalPages: number;
  currentPage: number;
  setCurrentPage: Function;
  limit: number;
};

const PaginationComponent = (props: Props) => {
  const nextPage = () => {
    if (props.currentPage !== props.totalPages)
      props.setCurrentPage(props.currentPage + 1);
  };
  const previousPage = () => {
    if (props.currentPage !== 1) {
      props.setCurrentPage(props.currentPage - 1);
    }
  };
  return (
    <nav>
      <ul className="pagination justify-content-center">
        <li className="page-item">
          <a className="page-link" href="#" onClick={previousPage}>
            &lt;
          </a>
        </li>
        <li className="page-item">
          <a className="page-link">{props.currentPage}</a>
        </li>

        <li className="page-item">
          <a className="page-link" href="#" onClick={nextPage}>
            &gt;
          </a>
        </li>
      </ul>
    </nav>
  );
};

export default PaginationComponent;
