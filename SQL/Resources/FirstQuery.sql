SELECT union_reporting.project.name AS PROJECT, union_reporting.test.name AS TEST, MIN(TIMESTAMPDIFF(SECOND, union_reporting.test.start_time, union_reporting.test.end_time)) AS MINI_WORKING_TIME FROM union_reporting.test JOIN union_reporting.project ON union_reporting.test.project_id = union_reporting.project.id GROUP BY union_reporting.project.name, union_reporting.test.name ORDER BY union_reporting.project.name, union_reporting.test.name;